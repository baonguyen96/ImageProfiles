using System;
using System.IO;
using ImageProfiles.Utility.Impl;

namespace ImageProfiles.Utility
{
	class ImageProfileFactory
	{
		public static AbstractProfileBase GetProfile(FileInfo file)
		{
			var extension = Path.GetExtension(file.Name);
			AbstractProfileBase profile = null;

			switch (extension)
			{
				case "jpg":
				case "JPG":
					profile = new JpgProfile(file);
					break;
				case "jpeg":
				case "JPEG":
					profile = new JpegProfile(file);
					break;
				default:
					throw new ApplicationException($"Unsupported file type ('{extension}')");
			}

			return profile;
		}
	}
}
