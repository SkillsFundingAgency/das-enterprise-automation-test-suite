DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @AWeekLessThan3Months DATETIME;
SET @AWeekLessThan3Months = DATEADD(WEEK, 1, DATEADD(MONTH, -3, GETDATE()));


UPDATE [dbo].[Application]
SET [dbo].[Application].CreatedOn = @AWeekLessThan3Months
WHERE [dbo].[Application].Details = @Details;
