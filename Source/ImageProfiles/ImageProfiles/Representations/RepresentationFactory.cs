using System;
using System.IO;
using ImageProfiles.Representations.Impl;

namespace ImageProfiles.Representations
{
	public class RepresentationFactory
	{
		public enum RepresentationMode
		{
			Database,
			FlatFile,
			Console
		}

		public static AbstractRepresentation GetRepresentation(RepresentationMode mode)
		{
			AbstractRepresentation representation;

			switch (mode)
			{
				case RepresentationMode.Database:
					representation = new ImageMetadataDatabaseRepresentation("localhost\\SQLEXPRESS", "DemoDB");
					break;
				case RepresentationMode.FlatFile:
					Directory.CreateDirectory("./ImageReports");
					var fileName = $"./ImageReports/ImageReport_{DateTime.Now:yyyyMMddhhmmss}.csv";
					representation = new ImageMetadataFlatFileRepresentation(fileName);
					break;
				case RepresentationMode.Console:
					representation = new ImageMetadataConsoleRepresentation();
					break;
				default:
					throw new ArgumentException($"Cannot determine mode '{mode}'");
			}

			return representation;
		}
	}
}