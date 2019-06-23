using System;
using System.IO;
using MetadataExtractor;

namespace ImageProfiles.Profiles.Impl
{
	internal class JpgProfile : AbstractProfileBase
	{
		public JpgProfile(FileInfo file) : base(file)
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
						if (directory.Name.Equals("XMP"))
						{
							if (tag.Name.Equals("Create Date"))
							{
								var date = tag.Description.Split('T')[0];
								var time = tag.Description.Split('T')[1];
								imageMetaData.DateTaken = DateTime.Parse($"{date.Replace('-', '/')} {time}");
							}
						}
						else if (directory.Name.Equals("Exif SubIFD"))
						{
							if (tag.Name.Equals("F-Number"))
							{
								imageMetaData.Aperture = string.IsNullOrEmpty(tag.Description)
									? 0
									: double.Parse(tag.Description.Replace("f/", ""));
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
