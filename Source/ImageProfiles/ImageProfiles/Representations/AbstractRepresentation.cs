using ImageProfiles.Profiles;

namespace ImageProfiles.Representations
{
	public abstract class AbstractRepresentation
	{
		protected AbstractRepresentation()
		{
		}

		public abstract void Save(ImageMetadata imageMetadata);
	}
}