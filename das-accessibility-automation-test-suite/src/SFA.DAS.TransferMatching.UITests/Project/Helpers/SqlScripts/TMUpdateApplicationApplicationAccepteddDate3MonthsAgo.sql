DECLARE @Details NVARCHAR(MAX);
SET @Details = '__Details__';
DECLARE @ThreeMonthsAgo DATETIME;
SET @ThreeMonthsAgo = DATEADD(Month, -3, GETDATE()-1);

UPDATE [dbo].[ApplicationStatusHistory]
SET CreatedOn = @ThreeMonthsAgo
WHERE EXISTS (
    SELECT 1
    FROM [dbo].[Application] app
    INNER JOIN [dbo].[ApplicationStatusHistory] hist
    ON hist.ApplicationId = app.Id
    AND app.Status = hist.Status
    AND app.Status = 3
    WHERE hist.Id = [dbo].[ApplicationStatusHistory].Id
    AND app.Id IN (
        SELECT Id
        FROM [dbo].[Application]
        WHERE Details = @Details
    )
)