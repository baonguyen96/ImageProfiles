using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageProfiles.Profiles;
using ImageProfiles.Representations;

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
				var root = new DirectoryInfo(@"D:\Bao\Pictures\Photography\Travel");
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
			var directories = GetOriginalDirectories(root);
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
		}

		public static List<DirectoryInfo> GetOriginalDirectories(DirectoryInfo root)
		{
			var directories = root.GetDirectories("*", SearchOption.AllDirectories)
				.Where(dir => !dir.Name.StartsWith("raw", StringComparison.InvariantCultureIgnoreCase))
				.Where(dir => !dir.Name.StartsWith("edit", StringComparison.InvariantCultureIgnoreCase))
				.Where(dir => dir.GetFiles().Any(file => !file.Name.Contains("Map")))
				.ToList();
			return directories;
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
			var allImages = directory.GetFiles();
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
			}).ToList();

			images = images.Where(im => im != null).ToList();

			if (editedDirectory != null && editedDirectory.Exists)
			{
				var editedImages = editedDirectory.GetFiles();

				foreach (var image in editedImages)
				{
					var im = images.FirstOrDefault(i => Path.GetFileNameWithoutExtension(i.Name)
						.StartsWith(Path.GetFileNameWithoutExtension(image.Name)));

					if (im != null)
					{
						im.IsChosen = true;
					}
				}
			}

			return images;
		}
	}
}