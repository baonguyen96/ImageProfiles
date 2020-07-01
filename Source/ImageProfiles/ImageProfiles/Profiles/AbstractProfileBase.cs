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

		protected ImageMetadata UpdateImageMetadataForUnrecognizedLens(ImageMetadata imageMetadata)
		{
			if (imageMetadata.DateTaken == null)
			{
				return imageMetadata;
			}

			if (IsRokinon12Lens(imageMetadata))
			{
				imageMetadata.LensModel = "Rokinon 12mm f/2.0 NSC CS";
				imageMetadata.FocalLength = 12;
			}
			else if (IsCanon50Lens(imageMetadata))
			{
				imageMetadata.LensModel = "Canon 50mm f/1.8";
				imageMetadata.FocalLength = 50;
			}
			else if (IsSigma50Lens(imageMetadata))
			{
				imageMetadata.LensModel = "Sigma 50mm f/1.4 HSM";
				imageMetadata.FocalLength = 50;
			}

			return imageMetadata;
		}


		private bool IsRokinon12Lens(ImageMetadata imageMetadata)
		{
			var isSony = imageMetadata.CameraMake.ToLowerInvariant().Contains("sony");
			var isAfterSept2019 = imageMetadata.DateTaken >= DateTime.Parse("09/02/2019");
			var doNotHaveLensInfo = string.IsNullOrEmpty(imageMetadata.LensModel) || imageMetadata.LensModel == "----";

			return isSony && isAfterSept2019 && doNotHaveLensInfo;
		}


		private bool IsCanon50Lens(ImageMetadata imageMetadata)
		{
			var isCanonRebelXt = imageMetadata.CameraModel.ToLowerInvariant().Contains("rebel");
			var is50mm = imageMetadata.FocalLength != null && (int) imageMetadata.FocalLength == 50 && imageMetadata.Aperture <= 2.8;

			return isCanonRebelXt && is50mm;
		}

		private bool IsSigma50Lens(ImageMetadata imageMetadata)
		{
			var isCanon7D = imageMetadata.CameraModel.ToLowerInvariant().Contains("7d");
			var is50mm = imageMetadata.FocalLength != null && (int)imageMetadata.FocalLength == 50;
			var isSigmaMetadata = string.IsNullOrEmpty(imageMetadata.LensModel) || imageMetadata.LensModel.Equals("50mm", StringComparison.CurrentCultureIgnoreCase);

			return isCanon7D && is50mm && isSigmaMetadata;
		}

	}
}
