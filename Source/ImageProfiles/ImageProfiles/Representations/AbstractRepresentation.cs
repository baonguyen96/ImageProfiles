using ImageProfiles.Profiles;

namespace ImageProfiles.Representations
{
	internal abstract class AbstractRepresentation
	{
		protected bool IsInitialLoad;

		protected AbstractRepresentation()
		{
			IsInitialLoad = true;
		}

		public abstract void Save(ImageMetadata imageMetadata);
	}
}
