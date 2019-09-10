IF OBJECT_ID('tempdb..#ClearSeededData') IS NOT NULL
BEGIN
    DROP PROC #ClearSeededData
END
GO
CREATE PROCEDURE #ClearSeededData
		@accountHashedId NVARCHAR(100),
		@legalEntityName NVARCHAR(100)
	AS
	BEGIN
		IF (EXISTS (SELECT 1 FROM [employer_account].[Account] WHERE Name = @legalEntityName AND HashedId = @accountHashedId))
		BEGIN
			declare @existing_accountId BIGINT
			declare @existing_legalEntityId BIGINT
			declare @existing_accountLegalEntityId BIGINT

			SELECT @existing_accountid = Id FROM [employer_account].[Account] WHERE Name = @legalEntityName AND HashedId = @accountHashedId

			DELETE FROM [employer_account].Paye where Ref in (select PayeRef from [employer_account].AccountHistory where AccountId = @existing_accountId)
			DELETE FROM [employer_account].AccountHistory where AccountId = @existing_accountId
			
			SELECT @existing_accountLegalEntityId = Id, @existing_legalEntityId = LegalEntityId from employer_account.AccountLegalEntity where AccountId = @existing_accountId
			
			DELETE FROM [employer_account].EmployerAgreement where AccountLegalEntityId = @existing_accountLegalEntityId
			DELETE FROM [employer_account].AccountLegalEntity where id = @existing_accountLegalEntityId
			DELETE FROM [employer_account].LegalEntity where id = @existing_legalEntityId

			DELETE FROM [employer_account].Membership Where AccountId = @existing_accountId

			DELETE FROM [employer_account].Account where id = @existing_accountId
		END

		IF (EXISTS (SELECT 1 FROM [employer_account].[User] WHERE Email = 'EASAutomatedTests@AccountApi.com'))
		BEGIN
			DELETE FROM [employer_account].[User] where Email = 'EASAutomatedTests@AccountApi.com'
		END
	END
GO
{0}

DROP PROCEDURE #ClearSeededData
GO