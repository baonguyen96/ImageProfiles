using System;
using System.IO;
using MetadataExtractor;

namespace ImageProfiles.Profiles.Impl
{
	internal class JpegProfile : AbstractProfileBase
	{
		public JpegProfile(FileInfo file) : base(file)
		{
		}

		public override ImageMetadata GetMetadata()
		{
			var imageMetaData = new ImageMetadata();

			try
			{
				var directories = ImageMetadataReader.ReadMetadata(File.FullName);

				imageMetaData.Path = File.DirectoryName;
				imageMetaData.Name = File.Name;

				foreach (var directory in directories)
				{
					foreach (var tag in directory.Tags)
					{
						if (directory.Name.Equals("JPEG"))
						{
							if (tag.Name.Equals("Image Height"))
							{
								imageMetaData.HeightInPixel = string.IsNullOrEmpty(tag.Description)
									? 0
									: int.Parse(tag.Description.Replace(" pixels", ""));
							}
							else if (tag.Name.Equals("Image Width"))
							{
								imageMetaData.WidthInPixel = string.IsNullOrEmpty(tag.Description)
									? 0
									: int.Parse(tag.Description.Replace(" pixels", ""));
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
								imageMetaData.Aperture = string.IsNullOrEmpty(tag.Description)
									? 0
									: double.Parse(tag.Description.Replace("f/", ""));
							}
							else if (tag.Name.Equals("ISO Speed Ratings"))
							{
								imageMetaData.Iso = string.IsNullOrEmpty(tag.Description)
									? 0
									: int.Parse(tag.Description);
							}
							else if (tag.Name.Equals("Exposure Bias Value"))
							{
								imageMetaData.ExposureBiasValue = tag.Description;
							}
							else if (tag.Name.Equals("Focal Length"))
							{
								imageMetaData.FocalLength = string.IsNullOrEmpty(tag.Description)
									? 0
									: double.Parse(tag.Description.Replace(" mm", ""));
							}
							else if (tag.Name.Equals("Lens Model"))
							{
								imageMetaData.LensModel = tag.Description;
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				var appException = new ApplicationException($"Error processing file {File.FullName}", e);
				throw appException;
			}

			return imageMetaData;
		}
	}
}
