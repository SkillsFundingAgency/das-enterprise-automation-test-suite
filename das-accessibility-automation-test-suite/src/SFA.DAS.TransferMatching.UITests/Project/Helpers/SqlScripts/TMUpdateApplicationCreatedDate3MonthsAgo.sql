DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @3MonthsAgo DATETIME;
SET @3MonthsAgo = DATEADD(Month, -3, GETDATE());


UPDATE [dbo].[Application]
SET [dbo].[Application].CreatedOn = @3MonthsAgo - 1
WHERE [dbo].[Application].Details = @Details;
