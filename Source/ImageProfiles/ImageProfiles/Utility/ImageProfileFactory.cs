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
				case ".jpg":
				case ".jpeg":
					profile = new JpgProfile(file);
					break;
				case ".JPG":
				case ".JPEG":
					profile = new JPEGProfile(file);
					break;
				default:
					throw new ApplicationException($"Unsupported file type ('{extension}')");
			}
			
			return profile;
		}
	}
}
