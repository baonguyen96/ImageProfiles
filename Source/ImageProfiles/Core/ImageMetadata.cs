using System;
using System.Text;

namespace Core
{
	class ImageMetadata
	{
		public string Name { get; set; }
		public int HeightInPixel { get; set; }
		public int WidthInPixel { get; set; }
		public string CameraMake { get; set; }
		public string CameraModel { get; set; }
		public string CameraFirmwareVersion { get; set; }
		public string LensModel { get; set; }
		public DateTime DateTaken { get; set; }
		public double FocalLength { get; set; }
		public double FocalLengthFullFrameEquivalent { get; set; }
		public string ShutterSpeed { get; set; }
		public double Aperture { get; set; }
		public int Iso { get; set; }
		public int ExposureBiasValue { get; set; }
		public bool IsChosen { get; set; }

		public override bool Equals(object obj)
		{
			return Name.Equals(((ImageMetadata) obj)?.Name);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override string ToString()
		{
			var str = new StringBuilder();
			str.Append($"Name: {Name}\r\n");
			str.Append($"HeightInPixel: {HeightInPixel}\r\n");
			str.Append($"WidthInPixel: {WidthInPixel}\r\n");
			str.Append($"CameraMake: {CameraMake}\r\n");
			str.Append($"CameraModel: {CameraModel}\r\n");
			str.Append($"CameraFirmwareVersion: {CameraFirmwareVersion}\r\n");
			str.Append($"LensModel: {LensModel}\r\n");
			str.Append($"DateTaken: {DateTaken}\r\n");
			str.Append($"FocalLength: {FocalLength}\r\n");
			str.Append($"FocalLengthFullFrameEquivalent: {FocalLengthFullFrameEquivalent}\r\n");
			str.Append($"ShutterSpeed: {ShutterSpeed}\r\n");
			str.Append($"Aperture: {Aperture}\r\n");
			str.Append($"Iso: {Iso}\r\n");
			str.Append($"ExposureBiasValue: {ExposureBiasValue}\r\n");
			str.Append($"IsChosem: {IsChosen}\r\n");
			return str.ToString();
		}
	}
}