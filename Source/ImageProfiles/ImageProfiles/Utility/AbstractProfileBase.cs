using System.IO;
using ImageProfiles.Model;

namespace ImageProfiles.Utility
{
	public abstract class AbstractProfileBase
	{
		protected readonly FileInfo File;

		protected AbstractProfileBase(FileInfo file)
		{
			File = file;
		}

		public abstract ImageMetadata GetMetadata();
	}
}
