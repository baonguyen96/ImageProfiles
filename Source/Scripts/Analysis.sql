------------------------------------
-- View
------------------------------------
SELECT * FROM [dbo].[ImageMetaData]


------------------------------------
-- Most used focal length
------------------------------------

SELECT [FocalLength], COUNT(1) AS [Total]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
GROUP BY [FocalLength]
ORDER BY COUNT(1) DESC



SELECT [FocalLength], COUNT(1) AS [Total]
FROM [dbo].[ImageMetadata] WITH(NOLOCK)
WHERE [IsChosen] = 1
GROUP BY [FocalLength]
ORDER BY COUNT(1) DESC



------------------------------------
-- Most used category
------------------------------------

SELECT [Category], [IsChosen], COUNT(1) AS [Total]
FROM
(
	SELECT
		CASE
			WHEN [FocalLength] < 24.0 THEN 'Ultrawide'
			WHEN [FocalLength] < 35.0 THEN 'Wide'
			WHEN [FocalLength] <= 50.0 THEN 'Standard'
			ELSE 'Tele' 
		END AS Category,
		[IsChosen]
	FROM [dbo].[ImageMetadata] WITH(NOLOCK)
) a
GROUP BY [Category], [IsChosen]
ORDER BY [Category], [IsChosen]


