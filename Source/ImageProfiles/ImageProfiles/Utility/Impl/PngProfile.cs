using System;
using System.IO;
using MetadataExtractor;

namespace ImageProfiles.Utility.Impl
{
	internal class PngProfile : AbstractProfileBase
	{
		public PngProfile(FileInfo file) : base(file)
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
						if (directory.Name.Equals("PNG -IHDR"))
						{
							if (tag.Name.Equals("Image Height"))
							{
								imageMetaData.HeightInPixel = string.IsNullOrEmpty(tag.Description)
									? 0
									: int.Parse(tag.Description);
							}
							else if (tag.Name.Equals("Image Width"))
							{
								imageMetaData.WidthInPixel = string.IsNullOrEmpty(tag.Description)
									? 0
									: int.Parse(tag.Description);
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
