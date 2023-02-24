Feature: ApiGetEmployerAccountsInternalAccountsIdUsers

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_12_ApiGetEmployerAccountsInternalAccountsIdUsers
	Then endpoint /api/accounts/internal/{accountId}/users can be accessed