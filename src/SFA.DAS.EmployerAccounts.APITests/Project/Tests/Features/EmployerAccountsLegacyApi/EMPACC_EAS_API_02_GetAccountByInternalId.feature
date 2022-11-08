Feature: GetAccountByInternalId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_02_GetAccountByInternalId
	Then endpoint /api/accounts/internal/{accountId} can be accessed