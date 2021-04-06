using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageProfiles.Profiles;
using ImageProfiles.Representations;
using ImageProfiles.Util;

namespace ImageProfiles
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var start = DateTime.Now;
			Console.WriteLine($"Start:    {start}");
			Console.WriteLine();

			try
			{
				var root = new DirectoryInfo(@"D:\Bao\Pictures\Photography\Travel\");
				var mode = RepresentationFactory.RepresentationMode.Database;
				var representation = RepresentationFactory.GetRepresentation(mode);
				ProcessAll(root, representation);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				var end = DateTime.Now;
				var duration = end - start;

				Console.WriteLine();
				Console.WriteLine($"End:      {end}");
				Console.WriteLine($"Run time: {duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}");
			}
		}

		private static void ProcessAll(DirectoryInfo root, AbstractRepresentation representation)
		{
			var lastRunDate = RunTimeUtil.GetLastRunTime();
			var directories = GetOriginalDirectories(root, lastRunDate);
			var maxLength = directories.Count.ToString().Length;
			var directoryCount = 1;
			var size = directories.Count;
			var tasks = new List<Task>();

			foreach (var directory in directories)
			{
				Console.WriteLine($"[{directoryCount.ToString($"D{maxLength}")} / {size.ToString($"D{maxLength}")}]: {directory.FullName}");

				var task = new Task(() => ProcessDirectory(directory, representation));
				tasks.Add(task);
				task.Start();

				directoryCount++;
			}

			Task.WaitAll(tasks.ToArray());
			RunTimeUtil.StoreRunTime(DateTime.Now);
		}

		public static List<DirectoryInfo> GetOriginalDirectories(DirectoryInfo root, DateTime? lastRun)
		{
			var directories = root.GetDirectories("*", SearchOption.AllDirectories)
				.Where(dir => !dir.Name.StartsWith("raw", StringComparison.InvariantCultureIgnoreCase))
				.Where(dir => !dir.Name.StartsWith("edit", StringComparison.InvariantCultureIgnoreCase))
				.Where(dir => dir.GetFiles().Any(file => !file.Name.Contains("Map")));
			
			if (directories == null || directories.Count() == 0)
			{
				directories = new List<DirectoryInfo>
				{
					root
				};
			}

			if (lastRun != null)
			{
				directories = directories.Where(dir => dir.LastWriteTime > lastRun.Value);
			}

			return directories.ToList();
		}

		public static void ProcessDirectory(DirectoryInfo directory, AbstractRepresentation representation)
		{
			var images = GetImageMetadataInDirectory(directory);

			foreach (var image in images)
			{
				representation.Save(image);
			}
		}

		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		private static List<ImageMetadata> GetImageMetadataInDirectory(DirectoryInfo directory)
		{
			var editedDirectory = directory.GetDirectories("*Edited*").FirstOrDefault()
			                      ?? directory.Parent.GetDirectories("*Edited*").FirstOrDefault();
			var allImages = directory.GetFiles().OrderBy(im => im.Name);
			var images = allImages.Select(image =>
			{
				try
				{
					return ImageProfileFactory.GetProfile(image).GetMetadata();
				}
				catch
				{
					return null;
				}
			})
				.Where(im => im != null)
				.OrderBy(im => im.Name)
				.ToList();

			
			if (editedDirectory != null && editedDirectory.Exists)
			{
				var editedImages = editedDirectory.GetFiles();

				for (var i = 0; i < images.Count; i++)
				{
					var currentImage = images[i];

					// find corresponding image in Edited
					var editedImage = editedImages.FirstOrDefault(im => Path.GetFileNameWithoutExtension(im.Name)
					.StartsWith(Path.GetFileNameWithoutExtension(currentImage.Name)));

					if (editedImage != null)
					{
						currentImage.IsChosen = true;
						ImageMetadata editedImageMetadata = null;

						try
						{
							editedImageMetadata = ImageProfileFactory.GetProfile(editedImage).GetMetadata();
						}
						catch
						{
							editedImageMetadata = null;
						}

						// check pano
						if (editedImageMetadata != null && editedImageMetadata.IsPanorama)
						{
							var currentCounter = FileUtil.GetFileCounter(currentImage.Name);
							
							// must have time component to check
							if (currentImage.DateTaken == null || !currentImage.DateTaken.HasValue)
							{
								var j = i + 1;

								for (; j < images.Count; j++)
								{
									var nextImage = images[j];
									var nextCounter = FileUtil.GetFileCounter(nextImage.Name);
									var timeDiff = (nextImage.DateTaken - currentImage.DateTaken).Value.TotalSeconds;

									//Console.WriteLine($"Current: {currentImage.Name} - {currentCounter} - {currentImage.DateTaken}");
									//Console.WriteLine($"Current: {nextImage.Name} - {nextCounter} - {nextImage.DateTaken}");
									//Console.WriteLine($"i: {i}, j: {j}, Timediff: {timeDiff}");

									if (nextCounter == currentCounter + (j - i) && timeDiff <= ((j - i) * 10))
									{
										nextImage.IsChosen = true;
									}
								}

								i = j;
							}
						}
					}
				}

				//var editedImages = editedDirectory.GetFiles();

				//foreach (var editedImage in editedImages)
				//{
				//	var im = images
				//		.FirstOrDefault(i => Path.GetFileNameWithoutExtension(i.Name)
				//		.StartsWith(Path.GetFileNameWithoutExtension(editedImage.Name)));

				//	if (im != null)
				//	{
				//		im.IsChosen = true;
				//	}
				//}
			}

			return images;
		}
	}
}