using System.Data.Entity;

namespace ImageProfiles.Model
{
	class ImageMetadataContext : DbContext
	{
		public DbSet<ImageMetadata> ImageMetadatas { get; set; }
	}
}
