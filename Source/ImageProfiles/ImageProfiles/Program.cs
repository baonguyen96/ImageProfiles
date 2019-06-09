using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageProfiles.Model;
using ImageProfiles.Utility;
using MetadataExtractor;

namespace ImageProfiles
{
	class Program
	{
		static void Main(string[] args)
		{
			var file = new FileInfo(
				@"G:\Pictures\Photography\Travel\USA\Texas\Dallas\Dallas Museum of Art\2015-07\_MG_2383.jpg");
			var directories = ImageMetadataReader.ReadMetadata(file.FullName);

			foreach (var directory in directories)
			{
				foreach (var tag in directory.Tags)
				{
					Console.WriteLine($"{directory.Name} - {tag.Name} - {tag.Description}");
				}
			}

			//			var root = new DirectoryInfo(@"G:\Pictures\Photography\Travel\USA\Texas\Dallas\Dallas Museum of Art\2015-07");
			//			TraverseDirectoryAndPopulateData(root);
		}

		public static void TraverseDirectoryAndPopulateData(DirectoryInfo directory)
		{
			if (directory.GetFiles().Any())
			{
				var images = GetImageMetadataInDirectory(directory);

				if (images.Any())
				{
					using (var db = new ImageMetadataContext())
					{
						db.ImageMetadatas.AddRange(images);
						db.SaveChanges();
					}
				}
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
					var im = imageMetadatas.First(i => i.Name.Equals(image.Name));
					im.IsChosen = true;
				}

			}

			return imageMetadatas;
		}
	}
}
