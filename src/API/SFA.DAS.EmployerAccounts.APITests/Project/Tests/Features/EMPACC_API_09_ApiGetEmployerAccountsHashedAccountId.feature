Feature: ApiGetEmployerAccountsHashedAccountId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_09_ApiGetEmployerAccountsHashedAccountId
	Then endpoint /api/accounts/{hashedAccountId} can be accessed