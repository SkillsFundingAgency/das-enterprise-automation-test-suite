Feature: GetTransactionSummary

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_13_GetTransactionSummary
	Then endpoint api/accounts/{hashedAccountId}/transactions from legacy accounts api can be accessed