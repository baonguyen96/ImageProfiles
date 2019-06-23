using System;

namespace ImageProfiles.Profiles
{
	public class ImageMetadata
	{
		public string Path { get; set; }
		public string Name { get; set; }
		public int? HeightInPixel { get; set; }
		public int? WidthInPixel { get; set; }
		public string CameraMake { get; set; }
		public string CameraModel { get; set; }
		public string CameraFirmwareVersion { get; set; }
		public string LensModel { get; set; }
		public DateTime? DateTaken { get; set; }
		public double? FocalLength { get; set; }
		public string ShutterSpeed { get; set; }
		public double? Aperture { get; set; }
		public int? Iso { get; set; }
		public string ExposureBiasValue { get; set; }
		public bool IsChosen { get; set; }
	}
}