Feature: ApiGetEmployerAccountsInternalAccountsId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_10_ApiGetEmployerAccountsInternalAccountsId
	Then endpoint /accounts/internal/{accountId} can be accessed