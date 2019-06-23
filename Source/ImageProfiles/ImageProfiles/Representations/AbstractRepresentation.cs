using ImageProfiles.Profiles;

namespace ImageProfiles.Representations
{
	internal abstract class AbstractRepresentation
	{
		protected ImageMetadata Image;

		protected AbstractRepresentation(ImageMetadata imageMetadata)
		{
			Image = imageMetadata;
		}

		public abstract string GetRepresentation();
	}
}
