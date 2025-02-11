DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @FiveWeeksAgo DATETIME;
SET @FiveWeeksAgo = DATEADD(WEEK, -5, GETDATE());


UPDATE [dbo].[Application]
SET [dbo].[Application].CreatedOn = @FiveWeeksAgo
WHERE [dbo].[Application].Details = @Details;
