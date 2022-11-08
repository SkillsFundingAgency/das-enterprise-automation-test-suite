Feature: GetTransactions

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_14_GetTransactions
	Then endpoint api/accounts/{accountId}/transactions/year/month can be accessed