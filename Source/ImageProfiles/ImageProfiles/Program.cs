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
				TraverseDirectoryAndPopulateData(root, OutputMode.Database);
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


		private static void TraverseDirectoryAndPopulateData(DirectoryInfo directory, OutputMode outputMode, bool atRootLevel = true)
		{
			// initialize as needed
			if (atRootLevel)
			{
				switch (outputMode)
				{
					case OutputMode.Database:
						DatabaseManager.Instance.ExecuteInsertOrUpdate(ImageMetadataDatabaseRepresentation.GetResetQuery());
						break;
					case OutputMode.FlatFile:
						FileManager.Instance.WriteHeader(ImageMetadataFlatFileRepresentation.GetHeader());
						break;
				}
			}

			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase) || 
			    directory.Name.Equals("Edited", StringComparison.InvariantCultureIgnoreCase))
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
						images.ForEach(image => DatabaseManager.Instance.ExecuteInsertOrUpdate(new ImageMetadataDatabaseRepresentation(image).GetRepresentation()));
						break;
					case OutputMode.FlatFile:
						images.ForEach(image => FileManager.Instance.WriteLine(new ImageMetadataFlatFileRepresentation(image).GetRepresentation()));
						break;
					case OutputMode.Console:
						images.ForEach(image => Console.WriteLine(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(outputMode), outputMode, null);
				}
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateData(directory: subDirectory, outputMode: outputMode, atRootLevel: false);
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