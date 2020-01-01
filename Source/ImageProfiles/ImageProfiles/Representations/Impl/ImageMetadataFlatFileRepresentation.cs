using System;
using System.IO;
using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	internal class ImageMetadataFlatFileRepresentation : AbstractRepresentation
	{
		private readonly string _fileName;

		public ImageMetadataFlatFileRepresentation(string fileName) : base()
		{
			_fileName = fileName;
		}
		
		private string GetHeader()
		{
			return "Path|" +
			       "Name|" +
			       "HeightInPixel|" +
			       "WidthInPixel|" +
			       "CameraMake|" +
			       "CameraModel|" +
			       "CameraFirmwareVersion|" +
			       "LensModel|" +
			       "DateTaken|" +
			       "FocalLength|" +
			       "ShutterSpeed|" +
			       "Aperture|" +
			       "Iso|" +
			       "ExposureBiasValue|" +
			       "IsChosen";
		}

		public static string GetString(ImageMetadata image)
		{
			return $"{image.Path}|" +
			       $"{image.Name}|" +
			       $"{image.HeightInPixel ?? 0}|" +
			       $"{image.WidthInPixel ?? 0}|" +
			       $"{image.CameraMake}|" +
			       $"{image.CameraModel}|" +
			       $"{image.CameraFirmwareVersion}|" +
			       $"{(image.LensModel == null ? "" : image.LensModel.Replace('|', ' '))}|" +
			       $"{(image.DateTaken == null ? "NULL" : image.DateTaken.ToString())}|" +
			       $"{image.FocalLength ?? 0}|" +
			       $"{image.ShutterSpeed}|" +
			       $"{image.Aperture ?? 0}|" +
			       $"{image.Iso}|" +
			       $"{image.ExposureBiasValue}|" +
			       $"{image.IsChosen}";
		}

		public override void Save(ImageMetadata image)
		{
			string line;

			if (IsInitialLoad)
			{
				line = GetHeader();
				IsInitialLoad = false;
			}
			else
			{
				line = GetString(image);
			}

			using (var sw = new StreamWriter(_fileName, true))
			{
				sw.WriteLine(line);
			}
		}
	}
}
