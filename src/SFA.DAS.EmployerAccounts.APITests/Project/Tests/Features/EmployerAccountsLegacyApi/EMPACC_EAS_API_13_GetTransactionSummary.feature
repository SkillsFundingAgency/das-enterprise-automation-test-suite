Feature: GetTransactionSummary

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_13_GetTransactionSummary
	Then endpoint api/accounts/{accountId}/transactions can be accessed