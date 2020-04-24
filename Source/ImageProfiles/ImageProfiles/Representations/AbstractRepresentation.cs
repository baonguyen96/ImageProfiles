using ImageProfiles.Profiles;

namespace ImageProfiles.Representations
{
	public abstract class AbstractRepresentation
	{
		protected static bool IsInitialLoad = true;

		protected AbstractRepresentation()
		{
		}

		public abstract void Save(ImageMetadata imageMetadata);
	}
}