using System;
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

		protected ImageMetadata UpdateImageMetadataForManualLens(ImageMetadata imageMetadata)
		{
			if (imageMetadata.DateTaken == null || imageMetadata.DateTaken < DateTime.Parse("09/02/2019"))
			{
				return imageMetadata;
			}

			if (string.IsNullOrEmpty(imageMetadata.LensModel) || imageMetadata.LensModel == "----")
			{
				imageMetadata.LensModel = "Rokinon 12mm f/2.0 NSC CS";
				imageMetadata.FocalLength = 12;
			}
			
			return imageMetadata;
		}
	}
}
