using ImageProfiles.Utility;

namespace ImageProfiles.Representation.Impl
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
			       $"{Image.HeightInPixel}|" +
			       $"{Image.WidthInPixel}|" +
			       $"{Image.CameraMake}|" +
			       $"{Image.CameraModel}|" +
			       $"{Image.CameraFirmwareVersion}|" +
			       $"{Image.LensModel}|" +
			       $"{Image.DateTaken}|" +
			       $"{Image.FocalLength}|" +
			       $"{Image.ShutterSpeed}|" +
			       $"{Image.Aperture}|" +
			       $"{Image.Iso}|" +
			       $"{Image.ExposureBiasValue}|" +
			       $"{Image.IsChosen}";
		}
	}
}
