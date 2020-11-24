using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ImageProfiles.Profiles;

namespace ImageProfiles.Representations.Impl
{
	internal class ImageMetadataDatabaseRepresentation : AbstractRepresentation
	{
		private readonly string _connectionString;
		private readonly List<string> _loadedDirs;

		public ImageMetadataDatabaseRepresentation(string server, string database) : base()
		{
			_connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=true;";
			_loadedDirs = new List<string>();
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

		private static string GetResetQuery(string path)
		{
			return $@"DELETE FROM [dbo].[ImageMetadata] WHERE [Path] = '{path}';";
		}

		public override void Save(ImageMetadata image)
		{
			string query;

			if (!_loadedDirs.Contains(image.Path))
			{
				query = GetResetQuery(image.Path);
				
				using (var connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					using (var sqlCommand = new SqlCommand(query, connection))
					{
						sqlCommand.ExecuteNonQuery();
					}
				}

				_loadedDirs.Add(image.Path);
			}

			query = GetInsertQuery(image);

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
