using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using static System.Double;

namespace Core
{
	class Program
	{
		static void Main(string[] args)
		{
			var imagePath = @"D:\Pictures\Photography\Travel\USA\Texas\Dallas\Northpark Mall\DSC00015.jpg";
			var mt = GetMetadata(new FileInfo(imagePath));
			Console.WriteLine(mt.ToString());
		}

		public static List<ImageMetadata> GetImageMetadataInDirectory(string directoryPath)
		{
			var directory = new DirectoryInfo(directoryPath);
			var editedDirectory = new DirectoryInfo(Path.Combine(directoryPath, "Edited"));
			var allImages = directory.GetFiles();
			var editedImages = editedDirectory.GetFiles();
			var imageMetadatas = allImages.Select(GetMetadata).ToList();

			foreach (var image in editedImages)
			{
				var im = imageMetadatas.First(i => i.Name.Equals(image.Name));
				im.IsChosen = true;
			}

			return imageMetadatas;
		}


		private static ImageMetadata GetMetadata(FileInfo file)
		{
			var directories = ImageMetadataReader.ReadMetadata(file.FullName);
			var imageMetaData = new ImageMetadata();

			// print out all metadata
			foreach (var directory in directories)
			{
				foreach (var tag in directory.Tags)
				{
					if (directory.Name.Equals("JPEG"))
					{
						if (tag.Name.Equals("Image Height"))
						{
							imageMetaData.HeightInPixel = string.IsNullOrEmpty(tag.Description) ? 0 : int.Parse(tag.Description.Replace(" pixels", ""));
						}
						else if (tag.Name.Equals("Image Width"))
						{
							imageMetaData.WidthInPixel = string.IsNullOrEmpty(tag.Description) ? 0 : int.Parse(tag.Description.Replace(" pixels", ""));
						}
					}
					if (directory.Name.Equals("Exif IFD0"))
					{
						if (tag.Name.Equals("Make"))
						{
							imageMetaData.CameraMake = tag.Description;
						}
						else if (tag.Name.Equals("Model"))
						{
							imageMetaData.CameraModel = tag.Description;
						}
						else if (tag.Name.Equals("Software"))
						{
							imageMetaData.CameraFirmwareVersion = tag.Description;
						}
						else if (tag.Name.Equals("Date/Time"))
						{
							var date = tag.Description.Split(' ')[0];
							var time = tag.Description.Split(' ')[1];
							imageMetaData.DateTaken = DateTime.Parse($"{date.Replace(':', '/')} {time}");
						}
					}
					else if (directory.Name.Equals("Exif SubIFD"))
					{
						if (tag.Name.Equals("Exposure Time"))
						{
							imageMetaData.ShutterSpeed = tag.Description.Replace(" sec", "");
						}
						else if (tag.Name.Equals("F-Number"))
						{
							imageMetaData.Aperture = string.IsNullOrEmpty(tag.Description) ? 0 : Parse(tag.Description.Replace("f/", ""));
						}
						else if (tag.Name.Equals("ISO Speed Ratings"))
						{
							imageMetaData.Iso = string.IsNullOrEmpty(tag.Description) ? 0 : int.Parse(tag.Description);
						}
						else if (tag.Name.Equals("Exposure Bias Value"))
						{
							imageMetaData.ExposureBiasValue = string.IsNullOrEmpty(tag.Description) ? 0 : int.Parse(tag.Description.Replace(" EV", ""));
						}
						else if (tag.Name.Equals("Focal Length"))
						{
							imageMetaData.FocalLength = string.IsNullOrEmpty(tag.Description) ? 0 : double.Parse(tag.Description.Replace(" mm", ""));
						}
						else if (tag.Name.Equals("Focal Length 35"))
						{
							imageMetaData.FocalLengthFullFrameEquivalent = string.IsNullOrEmpty(tag.Description) ? 0 : int.Parse(tag.Description.Replace(" mm", ""));
						}
						else if (tag.Name.Equals("Lens Model"))
						{
							imageMetaData.LensModel = tag.Description;
						}
					}
					else if (directory.Name.Equals("File"))
					{
						if (tag.Name.Equals("File Name"))
						{
							imageMetaData.Name = tag.Description;
						}
					}
				}
			}

			return imageMetaData;
		}
	}
}