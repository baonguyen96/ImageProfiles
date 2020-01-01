using System;
using System.Text;
using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	class ImageMetadataConsoleRepresentation : AbstractRepresentation
	{
		public override void Save(ImageMetadata image)
		{
			var str = new StringBuilder();
			str.Append($"Path: {image.Path}\r\n");
			str.Append($"Name: {image.Name}\r\n");
			str.Append($"HeightInPixel: {image.HeightInPixel}\r\n");
			str.Append($"WidthInPixel: {image.WidthInPixel}\r\n");
			str.Append($"CameraMake: {image.CameraMake}\r\n");
			str.Append($"CameraModel: {image.CameraModel}\r\n");
			str.Append($"CameraFirmwareVersion: {image.CameraFirmwareVersion}\r\n");
			str.Append($"LensModel: {image.LensModel}\r\n");
			str.Append($"DateTaken: {image.DateTaken}\r\n");
			str.Append($"FocalLength: {image.FocalLength}\r\n");
			str.Append($"ShutterSpeed: {image.ShutterSpeed}\r\n");
			str.Append($"Aperture: {image.Aperture}\r\n");
			str.Append($"Iso: {image.Iso}\r\n");
			str.Append($"ExposureBiasValue: {image.ExposureBiasValue}\r\n");
			str.Append($"IsChosem: {image.IsChosen}\r\n");

			Console.WriteLine(str);
		}
	}
}
