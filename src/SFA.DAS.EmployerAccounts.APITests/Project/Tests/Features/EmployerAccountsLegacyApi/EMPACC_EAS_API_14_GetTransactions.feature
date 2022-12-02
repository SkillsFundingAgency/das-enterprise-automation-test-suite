Feature: GetTransactions

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_14_GetTransactions
	Then endpoint api/accounts/{hashedAccountId}/transactions/year/month from legacy accounts api can be accessed