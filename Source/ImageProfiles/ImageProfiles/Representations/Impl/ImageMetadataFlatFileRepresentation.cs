using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	internal class ImageMetadataFlatFileRepresentation : AbstractRepresentation
	{
		public ImageMetadataFlatFileRepresentation(ImageMetadata imageMetadata) : base(imageMetadata)
		{
		}
		
		public static string GetHeader()
		{
			return "Path|Name|HeightInPixel|WidthInPixel|CameraMake|CameraModel|CameraFirmwareVersion|LensModel|DateTaken|FocalLength|ShutterSpeed|Aperture|Iso|ExposureBiasValue|IsChosen";
		}

		public override string GetRepresentation()
		{
			return $"{Image.Path}|" +
			       $"{Image.Name}|" +
			       $"{Image.HeightInPixel ?? 0}|" +
			       $"{Image.WidthInPixel ?? 0}|" +
			       $"{Image.CameraMake}|" +
			       $"{Image.CameraModel}|" +
			       $"{Image.CameraFirmwareVersion}|" +
			       $"{(Image.LensModel == null ? "" : Image.LensModel.Replace('|', ' '))}|" +
			       $"{(Image.DateTaken == null ? "NULL" : Image.DateTaken.ToString())}|" +
			       $"{Image.FocalLength ?? 0}|" +
			       $"{Image.ShutterSpeed}|" +
			       $"{Image.Aperture ?? 0}|" +
			       $"{Image.Iso}|" +
			       $"{Image.ExposureBiasValue}|" +
			       $"{Image.IsChosen}";
		}
	}
}
