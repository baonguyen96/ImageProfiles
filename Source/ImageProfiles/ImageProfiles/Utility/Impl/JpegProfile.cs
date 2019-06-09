using System;
using System.IO;
using ImageProfiles.Model;
using MetadataExtractor;

namespace ImageProfiles.Utility.Impl
{
	class JpegProfile : AbstractProfileBase
	{
		public JpegProfile(FileInfo file) : base(file)
		{
		}

		public override ImageMetadata GetMetadata()
		{
			var directories = ImageMetadataReader.ReadMetadata(File.FullName);
			var imageMetaData = new ImageMetadata();

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
					else if (directory.Name.Equals("Exif IFD0"))
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
							imageMetaData.Aperture = string.IsNullOrEmpty(tag.Description) ? 0 : double.Parse(tag.Description.Replace("f/", ""));
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
