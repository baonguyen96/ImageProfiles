using System;
using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	internal class ImageMetadataDatabaseRepresentation : AbstractRepresentation
	{
		public ImageMetadataDatabaseRepresentation(ImageMetadata imageMetadata) : base(imageMetadata)
		{
		}
		
		public override string GetRepresentation()
		{
			return $@"
				INSERT INTO [dbo].[ImageMetadata]
				(
					[Path], 
					[Name], 
					[HeightInPixel], 
					[WidthInPixel], 
					[CameraMake], 
					[CameraModel], 
					[CameraFirmwareVersion], 
					[LensModel], 
					[DateTaken], 
					[FocalLength], 
					[ShutterSpeed],
					[Aperture],
					[ISO],
					[ExposureBiasValue],
					[IsChosen],
					[CreatedOn],
					[UpdatedOn]
				)
				VALUES
				(
					'{Image.Path}',
					'{Image.Name}',
					{Image.HeightInPixel ?? 0},
					{Image.WidthInPixel ?? 0},
					'{Image.CameraMake}',
					'{Image.CameraModel}',
					'{Image.CameraFirmwareVersion}',
					'{Image.LensModel}',
					'{Image.DateTaken}',
					'{Image.FocalLength}',
					'{Image.ShutterSpeed}',
					{Image.Aperture ?? 0},
					{Image.Iso ?? 0},
					'{Image.ExposureBiasValue}',
					{(Image.IsChosen ? "1" : "0")},
					'{DateTime.Now}',
					'{DateTime.Now}'
				);";
		}

		public static string GetResetQuery()
		{
			return "TRUNCATE TABLE [dbo].[ImageMetadata];";
		}
	}
}
