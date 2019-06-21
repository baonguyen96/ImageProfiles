using System.Text;
using ImageProfiles.Utility;

namespace ImageProfiles.Representation
{
	class ImageMetadataConsoleRepresentation : AbstractRepresentation
	{
		public ImageMetadataConsoleRepresentation(ImageMetadata imageMetadata) : base(imageMetadata)
		{
		}

		public override string GetRepresentation()
		{
			var str = new StringBuilder();
			str.Append($"Path: {Image.Path}\r\n");
			str.Append($"Name: {Image.Name}\r\n");
			str.Append($"HeightInPixel: {Image.HeightInPixel}\r\n");
			str.Append($"WidthInPixel: {Image.WidthInPixel}\r\n");
			str.Append($"CameraMake: {Image.CameraMake}\r\n");
			str.Append($"CameraModel: {Image.CameraModel}\r\n");
			str.Append($"CameraFirmwareVersion: {Image.CameraFirmwareVersion}\r\n");
			str.Append($"LensModel: {Image.LensModel}\r\n");
			str.Append($"DateTaken: {Image.DateTaken}\r\n");
			str.Append($"FocalLength: {Image.FocalLength}\r\n");
			str.Append($"ShutterSpeed: {Image.ShutterSpeed}\r\n");
			str.Append($"Aperture: {Image.Aperture}\r\n");
			str.Append($"Iso: {Image.Iso}\r\n");
			str.Append($"ExposureBiasValue: {Image.ExposureBiasValue}\r\n");
			str.Append($"IsChosem: {Image.IsChosen}\r\n");
			return str.ToString();
		}
	}
}
