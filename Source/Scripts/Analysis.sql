
------------------------------------
-- Reset
------------------------------------
TRUNCATE TABLE [dbo].[ImageMetaData]


------------------------------------
-- View
------------------------------------

SELECT * 
FROM [dbo].[ImageMetaData] WITH(NOLOCK)
WHERE CONCAT([CameraMake], ' - ', [CameraModel]) = ' - '
ORDER BY [DateTaken] DESC


------------------------------------
-- Most used camera
------------------------------------

SELECT CONCAT([CameraMake], ' - ', [CameraModel]) AS [Camera], COUNT(1) AS [TotalPictureTaken]
FROM [dbo].[ImageMetaData] WITH(NOLOCK)
--WHERE COALESCE([CameraMake], '') <> ''
GROUP BY CONCAT([CameraMake], ' - ', [CameraModel])
ORDER BY [TotalPictureTaken] DESC


------------------------------------
-- Most used lens
------------------------------------

SELECT 
	[LensModel], 
	COUNT(1) AS [Total],
	SUM(CAST([IsChosen] AS INT)) AS [TotalChosen], 
	SUM(CAST([IsChosen] AS FLOAT)) / CAST(COUNT(1) AS FLOAT) AS [ChosenPercentage]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
WHERE COALESCE(NULLIF([LensModel], ''), '----') <> '----'
GROUP BY [LensModel]
ORDER BY [TotalChosen] DESC



------------------------------------
-- Most used focal length
------------------------------------

SELECT DISTINCT [FocalLength]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
ORDER BY [FocalLength]


SELECT *
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
WHERE [FocalLength] < 10
ORDER BY [FocalLength] 


SELECT 
	[FocalLength], 
	[FocalLength] * 1.5 AS [35EquivalentFocalLength],
	COUNT(1) AS [Total], 
	SUM(CAST([IsChosen] AS INT)) AS [TotalChosen], 
	SUM(CAST([IsChosen] AS FLOAT)) / CAST(COUNT(1) AS FLOAT) AS [ChosenPercentage]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
WHERE [FocalLength] > 0
	--AND [LensModel] NOT LIKE '%24%'
	--AND [LensModel] NOT LIKE '%30%'
GROUP BY [FocalLength]
HAVING SUM(CAST([IsChosen] AS INT)) > 
(
	SELECT AVG(CAST([IsChosen] AS FLOAT)) * 100
	FROM [dbo].[ImageMetadata] WITH(NOLOCK)
	WHERE [FocalLength] > 0
)
ORDER BY [TotalChosen] DESC




------------------------------------
-- Most used category
------------------------------------

;WITH cte AS
(
	SELECT
		CASE
			WHEN [FocalLength] <= 18.0 THEN 'Ultrawide [0mm, 18mm]'
			WHEN [FocalLength] <= 28.0 THEN 'Wide [19mm, 28mm]'
			WHEN [FocalLength] <= 50.0 THEN 'Standard [29mm, 50mm]'
			ELSE 'Tele [51mm, infinity)' 
		END AS Category,
		CAST([IsChosen] AS FLOAT) AS [IsChosen]
	FROM [dbo].[ImageMetadata] WITH(NOLOCK)
	WHERE [FocalLength] >= 10 -- widest lens was Canon 10-18 so below are invalid or manual lenses 
)
SELECT 
	[Category], 
	COUNT(1) AS [Total], 
	SUM([IsChosen]) AS [TotalChosen], 
	SUM([IsChosen]) / CAST(COUNT(1) AS FLOAT) AS [ChosenPercentage]
FROM cte
GROUP BY [Category]
ORDER BY [ChosenPercentage] DESC



------------------------------------
-- Date range of most chosen pics
------------------------------------

SELECT EOMONTH([DateTaken]) AS [MonthTaken], COUNT(1) AS [Total]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
WHERE [IsChosen] = 1
	AND [FocalLength] BETWEEN 19 AND 28
GROUP BY EOMONTH([DateTaken]) 
ORDER BY [Total] DESC



------------------------------------
-- Other research
------------------------------------


-- Find all distinct file type case sensitive
SELECT DISTINCT TOP 100 RIGHT([Name], 4) COLLATE SQL_Latin1_General_CP1_CS_AS AS FileExtension
FROM [dbo].[ImageMetadata] WIHT(NOLOCK)


-- PNG population is so small so can be skipped for now
SELECT TOP 100 *
FROM [dbo].[ImageMetadata] WIHT(NOLOCK)
WHERE [Name] LIKE '%.JPG'


-- Find examples of each type
; WITH #FileExtensions AS 
(
	SELECT 
		[Id], 
		RIGHT([Name], 4) COLLATE SQL_Latin1_General_CP1_CS_AS AS FileExtension,
		ROW_NUMBER() OVER (PARTITION BY RIGHT([Name], 4) COLLATE SQL_Latin1_General_CP1_CS_AS ORDER BY [DateTaken] DESC) AS Ranker
	FROM [dbo].[ImageMetadata] WIHT(NOLOCK)
)
SELECT im.*
FROM [dbo].[ImageMetadata] im WITH(NOLOCK)
INNER JOIN #FileExtensions fe 
	ON im.ID = fe.ID
WHERE fe.Ranker < 10
ORDER BY [fe].[FileExtension], [fe].[Ranker]



