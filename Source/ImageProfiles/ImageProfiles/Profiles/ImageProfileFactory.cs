using System;
using System.IO;
using ImageProfiles.Profiles.Impl;

namespace ImageProfiles.Profiles
{
	internal class ImageProfileFactory
	{
		public static AbstractProfileBase GetProfile(FileInfo file)
		{
			var extension = Path.GetExtension(file.Name);
			AbstractProfileBase profile = null;

			switch (extension)
			{
//				case ".jpg":
				case ".jpeg":
					profile = new JpgProfile(file);
					break;
				case ".jpg":
				case ".JPG":
				case ".JPEG":
					profile = new JpegProfile(file);
					break;
				case ".png":
				case ".PNG":
					profile = new PngProfile(file);
					break;
				default:
					throw new ApplicationException($"Unsupported file type '{extension}' for file '{file.FullName}'");
			}
			
			return profile;
		}
	}
}
