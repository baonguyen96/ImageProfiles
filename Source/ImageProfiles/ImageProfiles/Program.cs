using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageProfiles.OutputAdapters;
using ImageProfiles.Profiles;
using ImageProfiles.Representations.Impl;

namespace ImageProfiles
{
	internal class Program
	{
		private enum OutputMode
		{
			Database,
			FlatFile,
			Console
		}

		private static void Main(string[] args)
		{
			var start = DateTime.Now;
			Console.WriteLine($"Start:    {start}");
			Console.WriteLine();

			try
			{
				var root = new DirectoryInfo(@"G:\Pictures\Photography\Travel");
				TraverseDirectoryAndPopulateData(root, OutputMode.FlatFile);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}\r\n" +
				                  $"{e.StackTrace}");
			}
			finally
			{
				var end = DateTime.Now;
				var duration = (end - start).TotalSeconds;

				Console.WriteLine();
				Console.WriteLine($"End:      {end}");
				Console.WriteLine($"Run time: {duration} second(s)");
			}
		}


		private static void TraverseDirectoryAndPopulateData(DirectoryInfo directory, OutputMode outputMode)
		{
			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase))
			{
				// skip
			}
			else if (directory.GetFiles().Any(file => !file.Name.Contains("Map")))
			{
				Console.WriteLine(directory.FullName);

				var images = GetImageMetadataInDirectory(directory);

				switch (outputMode)
				{
					case OutputMode.Database:
						images.ForEach(image => DatabaseManager.Instance.ExecuteInsert(new ImageMetadataDatabaseRepresentation(image).GetRepresentation()));
						break;
					case OutputMode.FlatFile:
						FileManager.Instance.WriteLine(ImageMetadataFlatFileRepresentation.GetHeader());
						images.ForEach(image => FileManager.Instance.WriteLine(new ImageMetadataFlatFileRepresentation(image).GetRepresentation()));
						break;
					case OutputMode.Console:
						images.ForEach(image => Console.WriteLine(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
						break;
					default:
						images.ForEach(image => Console.WriteLine(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
						break;
				}
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateData(subDirectory, outputMode);
				}
			}
		}

		

		private static List<ImageMetadata> GetImageMetadataInDirectory(DirectoryInfo directory)
		{
			var editedDirectory = new DirectoryInfo(Path.Combine(directory.FullName, "Edited"));
			var allImages = directory.GetFiles();
			var imageMetadatas = allImages.Select(image =>
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

			imageMetadatas = imageMetadatas.Where(im => im != null).ToList();

			if (editedDirectory.Exists)
			{
				var editedImages = editedDirectory.GetFiles();
				foreach (var image in editedImages)
				{
					var im = imageMetadatas.FirstOrDefault(i =>
						// ReSharper disable once PossibleNullReferenceException
						Path.GetFileNameWithoutExtension(i.Name).Equals(Path.GetFileNameWithoutExtension(image.Name)));

					if (im != null)
					{
						im.IsChosen = true;
					}
				}
			}

			return imageMetadatas;
		}
	}
}