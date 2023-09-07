DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @SixWeeksAgo DATETIME;
SET @SixWeeksAgo = DATEADD(WEEK, -6, GETDATE());


UPDATE [dbo].[Application]
SET [dbo].[Application].CreatedOn = @SixWeeksAgo
WHERE [dbo].[Application].Details = @Details;
