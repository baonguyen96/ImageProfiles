USE [DemoDB]
GO

/****** Object:  Table [dbo].[BankList]    Script Date: 5/27/2019 7:27:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Images]') IS NOT NULL 
	DROP TABLE [dbo].[Images]

CREATE TABLE [dbo].[Images](
	[ID] [BIGINT] IDENTITY(1,1) NOT NULL,
	[Name] [NVARCHAR](256) NOT NULL,
	[DateTaken] [DATETIME2](7) NULL,
	[WidthInPx] [INT] NULL,
	[HeightInPx] [INT] NULL,
	[CameraMaker] [NVARCHAR](256) NULL,
	[CameraModel] [NVARCHAR](256) NULL,
	[FStop] [NVARCHAR](256) NULL,
	[ShutterSpeed] [NVARCHAR](256) NULL,
	[ISO] [NVARCHAR](256) NULL,
	[ExposureCompensationStep] [NVARCHAR](256) NULL,
	[FocalLength] [NVARCHAR](256) NULL,
	[FlashMode] [NVARCHAR](256) NULL,
	[ShootingMode] [NVARCHAR](256) NULL,
	[CreatedOn] [DATETIME2](7) NULL,
	[UpdatedOn] [DATETIME2](7) NULL
) ON [PRIMARY]
GO

GO



