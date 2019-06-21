using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageProfiles.Representation;
using ImageProfiles.Utility;

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
				var outputMode = OutputMode.Database;
				TraverseDirectoryAndPopulateData(root, outputMode);
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
			if (outputMode == OutputMode.Database)
			{
//				TraverseDirectoryAndPopulateDatabase(directory);
				TraverseDirectoryAndPopulateData(directory, outputMode, null);
			}
			else if(outputMode == OutputMode.FlatFile)
			{
				Directory.CreateDirectory("./ImageReports");
				var fileName = $"./ImageReports/ImageReport_{DateTime.Now.ToString("yyyyMMddhhmmss")}.csv";

				using (var sw = new StreamWriter(fileName, true))
				{
					sw.WriteLine(ImageMetadataFlatFileRepresentation.GetHeader());
				}

				//				TraverseDirectoryAndPopulateFlatFile(directory, fileName);
				TraverseDirectoryAndPopulateData(directory, outputMode, fileName);

			}
			else
			{
				//				TraverseDirectoryAndPopulateDatabase(directory);
				TraverseDirectoryAndPopulateData(directory, outputMode, null);

			}
		}


		private static void TraverseDirectoryAndPopulateData(DirectoryInfo directory, OutputMode outputMode, string fileName)
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
						using (var sw = new StreamWriter(fileName, true))
						{
							images.ForEach(image => sw.WriteLine(new ImageMetadataFlatFileRepresentation(image).GetRepresentation()));
						}
						break;
					case OutputMode.Console:
						images.ForEach(image => DatabaseManager.Instance.ExecuteInsert(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
						break;
					default:
						images.ForEach(image => DatabaseManager.Instance.ExecuteInsert(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
						break;
				}
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateData(subDirectory, outputMode, fileName);
				}
			}
		}


		private static void TraverseDirectoryAndPopulateDatabase(DirectoryInfo directory)
		{
			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase))
			{
				// skip
			}
			else if (directory.GetFiles().Any(file => !file.Name.Contains("Map")))
			{
				Console.WriteLine(directory.FullName);

				var images = GetImageMetadataInDirectory(directory);
				images.ForEach(image => DatabaseManager.Instance.ExecuteInsert(new ImageMetadataDatabaseRepresentation(image).GetRepresentation()));
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateDatabase(subDirectory);
				}
			}
		}


		private static void TraverseDirectoryAndPopulateFlatFile(DirectoryInfo directory, string fileName)
		{
			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase))
			{
				// skip
			}
			else if (directory.GetFiles().Any(file => !file.Name.Contains("Map")))
			{
				Console.WriteLine(directory.FullName);

				var images = GetImageMetadataInDirectory(directory);

				using (var sw = new StreamWriter(fileName, true))
				{
					images.ForEach(image => sw.WriteLine(new ImageMetadataFlatFileRepresentation(image).GetRepresentation()));
				}
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateFlatFile(subDirectory, fileName);
				}
			}
		}


		private static void TraverseDirectoryAndOutputConsole(DirectoryInfo directory)
		{
			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase))
			{
				// skip
			}
			else if (directory.GetFiles().Any(file => !file.Name.Contains("Map")))
			{
				Console.WriteLine(directory.FullName);

				var images = GetImageMetadataInDirectory(directory);
				images.ForEach(image => DatabaseManager.Instance.ExecuteInsert(new ImageMetadataConsoleRepresentation(image).GetRepresentation()));
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateDatabase(subDirectory);
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
					var profile = ImageProfileFactory.GetProfile(image);
					return profile.GetMetadata();
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