DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @SixWeeksAgo DATETIME;
SET @SixWeeksAgo = DATEADD(WEEK, -6, GETDATE());

UPDATE [dbo].[ApplicationStatusHistory]
SET CreatedOn = @SixWeeksAgo
WHERE EXISTS (
    SELECT 1
    FROM [dbo].[Application] app
    INNER JOIN [dbo].[ApplicationStatusHistory] hist
    ON hist.ApplicationId = app.Id
    AND app.Status = hist.Status
    AND app.Status = 1
    WHERE hist.Id = [dbo].[ApplicationStatusHistory].Id
    AND app.Id IN (
        SELECT Id
        FROM [dbo].[Application]
        WHERE Details = @Details
    )
)