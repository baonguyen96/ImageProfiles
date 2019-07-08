------------------------------------
-- View
------------------------------------

SELECT * 
FROM [dbo].[ImageMetaData]
WHERE [FocalLength] = 20
	AND [IsChosen] = 1

------------------------------------
-- Most used focal length
------------------------------------

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
ORDER BY [ChosenPercentage] DESC




------------------------------------
-- Most used category
------------------------------------

;WITH cte AS
(
	SELECT
		CASE
			WHEN [FocalLength] <= 18.0 THEN 'Ultrawide'
			WHEN [FocalLength] <= 28.0 THEN 'Wide'
			WHEN [FocalLength] <= 50.0 THEN 'Standard'
			ELSE 'Tele' 
		END AS Category,
		CAST([IsChosen] AS FLOAT) AS [IsChosen]
	FROM [dbo].[ImageMetadata] WITH(NOLOCK)
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
-- Reset
------------------------------------
TRUNCATE TABLE [dbo].[ImageMetaData]