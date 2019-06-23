using System.IO;

namespace ImageProfiles.Profiles
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
