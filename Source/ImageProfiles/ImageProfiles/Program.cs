using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageProfiles.Utility;
using MetadataExtractor;

namespace ImageProfiles
{
	class Program
	{
		static void Main(string[] args)
		{
//			var file = new FileInfo(@"G:\Pictures\Photography\Travel\USA\Texas\Plano\Plano East Campus\0L3X6970.JPG");
//			var file = new FileInfo(@"G:\Pictures\Photography\Travel\USA\Texas\Dallas\Dallas Museum of Art\2015-07\_MG_2406.jpg");
//			var directories = ImageMetadataReader.ReadMetadata(file.FullName);
//
//			foreach (var directory in directories)
//			{
//				foreach (var tag in directory.Tags)
//				{
//					Console.WriteLine($"{directory.Name} - {tag.Name} - {tag.Description}");
//				}
//			}

			var root = new DirectoryInfo(@"G:\Pictures\Photography\Travel\USA\Texas\Dallas\Dallas Museum of Art");
			TraverseDirectoryAndPopulateData(root);
		}
		

		public static void TraverseDirectoryAndPopulateData(DirectoryInfo directory)
		{
			if (directory.Name.Equals("raw", StringComparison.InvariantCultureIgnoreCase))
			{
				// skip
			}
			else if (directory.GetFiles().Any())
			{
				var images = GetImageMetadataInDirectory(directory);

				if (images.Any())
				{
					Console.WriteLine(string.Join("\n", images.Select(image => image.ToString())));
				}

//				Console.WriteLine(directory.FullName);
			}
			else
			{
				foreach (var subDirectory in directory.GetDirectories())
				{
					TraverseDirectoryAndPopulateData(subDirectory);
				}
			}
		}
		

		public static List<ImageMetadata> GetImageMetadataInDirectory(DirectoryInfo directory)
		{
			var editedDirectory = new DirectoryInfo(Path.Combine(directory.FullName, "Edited"));
			var allImages = directory.GetFiles();
			var imageMetadatas = allImages.Select(image => ImageProfileFactory.GetProfile(image).GetMetadata()).ToList();

			if (editedDirectory.Exists)
			{
				var editedImages = editedDirectory.GetFiles();
				foreach (var image in editedImages)
				{
					var im = imageMetadatas.FirstOrDefault(i => i.Name.Equals(image.Name));

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
