IF OBJECT_ID('tempdb..#CreateAccount') IS NOT NULL
BEGIN
    DROP PROC #CreateAccount
END
GO
CREATE PROCEDURE #CreateAccount
		@accountHashedId NVARCHAR(100),
		@accountPublicHashedId NVARCHAR(100),
		@legalEntityCode NVARCHAR(50), 
		@legalEntityName NVARCHAR(100),
		@legalEntityRegisteredAddress NVARCHAR(256),
		@legalEntityDateOfIncorporation DATETIME,
		@legalEntityStatus NVARCHAR(50),
		@legalEntitySource TINYINT,
		@payeRef NVARCHAR(16),
		@payeName VARCHAR(500),
		@publicHashedId NVARCHAR(100),
		@userFirstName NVARCHAR(100),
		@userLastName NVARCHAR(100),
		@userEmailAddress NVARCHAR(100)
		
	AS
	BEGIN
		DECLARE @userRef UNIQUEIDENTIFIER = NewId()
		EXECUTE [employer_account].[UpsertUser] @userRef, @userEmailAddress, @userFirstName, @userLastName 
		DECLARE @userId BIGINT = (SELECT Id FROM [employer_account].[User] WHERE UserRef = @userRef)


		DECLARE @accountId BIGINT
		DECLARE @now DATETIME = GETDATE()
		DECLARE @legalEntityId BIGINT
		DECLARE @employerAgreementId BIGINT
		DECLARE @accountLegalEntityId BIGINT
		DECLARE @accountLegalEntityCreated BIT

		INSERT INTO [employer_account].[Account] (HashedId, PublicHashedId, Name, CreatedDate)
		VALUES (@accountHashedId, @accountPublicHashedId, @legalEntityName, GETDATE())
		
		SET @accountId = SCOPE_IDENTITY()

		INSERT INTO [employer_account].[Membership] (AccountId, UserId, [Role])
		VALUES (@accountId, @userId, 1)

		EXEC [employer_account].[CreateLegalEntityWithAgreement] 
				@accountId=@accountId,
				@companyNumber=@legalEntityCode, 
				@companyName=@legalEntityName, 
				@companyAddress=@legalEntityRegisteredAddress, 
				@companyDateOfIncorporation=@legalEntityDateOfIncorporation, 
				@Status=@legalEntityStatus, 
				@source=@legalEntitySource, 
				@publicSectorDataSource=NULL, 
				@legalEntityId=@legalEntityId OUTPUT, 
				@employerAgreementId=@employerAgreementId OUTPUT,
				@sector=null,
				@agreementType=0,
				@accountLegalEntityId=@accountLegalEntityId OUTPUT,
				@accountLegalEntityCreated=@accountLegalEntityCreated OUTPUT

		EXEC [Employer_account].[UpdateAccountLegalEntity_SetPublicHashedId] @accountLegalEntityId=@accountLegalEntityId, @PublicHashedId=@publicHashedId
		EXEC [employer_account].[SignEmployerAgreement] @employerAgreementId, @userId, 'Automated Test User', @now
		EXEC [employer_account].[CreatePaye] @payeRef, 'accessToken', 'refreshToken', @payeName, null
		EXEC [employer_account].[CreateAccountHistory] @accountId, @payeRef, @now
   END
GO
{0}

DROP PROCEDURE #CreateAccount
GO