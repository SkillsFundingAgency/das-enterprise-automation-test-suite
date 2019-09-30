BEGIN TRANSACTION

DECLARE @accountId BIGINT = 8080

DELETE aple
FROM AccountProviderLegalEntities aple
INNER JOIN AccountProviders ap ON ap.Id = aple.AccountProviderId
WHERE ap.AccountId = @accountId

DELETE FROM AccountProviders WHERE AccountId = @accountId

COMMIT TRANSACTION