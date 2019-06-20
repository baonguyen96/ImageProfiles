using System.IO;

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
