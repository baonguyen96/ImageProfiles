using System;
using System.Data.SqlClient;
using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	internal class ImageMetadataDatabaseRepresentation : AbstractRepresentation
	{
		private readonly string _connectionString;

		public ImageMetadataDatabaseRepresentation(string server, string database) : base()
		{
			_connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=true;";
		}
		
		private static string GetInsertQuery(ImageMetadata image)
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
					'{image.Path}',
					'{image.Name}',
					{image.HeightInPixel ?? 0},
					{image.WidthInPixel ?? 0},
					'{image.CameraMake}',
					'{image.CameraModel}',
					'{image.CameraFirmwareVersion}',
					'{image.LensModel}',
					'{image.DateTaken}',
					'{image.FocalLength}',
					'{image.ShutterSpeed}',
					{image.Aperture ?? 0},
					{image.Iso ?? 0},
					'{image.ExposureBiasValue}',
					{(image.IsChosen ? "1" : "0")},
					'{DateTime.Now}',
					'{DateTime.Now}'
				);";
		}

		private static string GetResetQuery()
		{
			return "TRUNCATE TABLE [dbo].[ImageMetadata];";
		}

		public override void Save(ImageMetadata image)
		{
			string query;

			if (IsInitialLoad)
			{
				query = GetResetQuery();
				IsInitialLoad = false;
			}
			else
			{
				query = GetInsertQuery(image);
			}

			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var sqlCommand = new SqlCommand(query, connection))
				{
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
