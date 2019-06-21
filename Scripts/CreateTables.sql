USE [DemoDB]
GO

/****** Object:  Table [dbo].[BankList]    Script Date: 5/27/2019 7:27:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[ImageMetadata]') IS NOT NULL 
	DROP TABLE [dbo].[ImageMetadata]

CREATE TABLE [dbo].[ImageMetadata](
	[ID] [BIGINT] IDENTITY(1,1) NOT NULL,
	[Path] [NVARCHAR](256) NOT NULL,
	[Name] [NVARCHAR](256) NOT NULL,
	[HeightInPixel] [INT] NULL,
	[WidthInPixel] [INT] NULL,
	[CameraMake] [NVARCHAR](256) NULL,
	[CameraModel] [NVARCHAR](256) NULL,
	[CameraFirmwareVersion] [NVARCHAR](256) NULL,
	[LensModel] [NVARCHAR](256) NULL,
	[DateTaken] [DATETIME2](7) NULL,
	[FocalLength] [FLOAT] NULL,
	[ShutterSpeed] [NVARCHAR](256) NULL,
	[Aperture] [FLOAT] NULL,
	[ISO] [INT] NULL,
	[ExposureBiasValue] [NVARCHAR](256) NULL,
	[IsChosen] [BIT] NULL,
	[CreatedOn] [DATETIME2](7) NULL,
	[UpdatedOn] [DATETIME2](7) NULL
) ON [PRIMARY]
GO




