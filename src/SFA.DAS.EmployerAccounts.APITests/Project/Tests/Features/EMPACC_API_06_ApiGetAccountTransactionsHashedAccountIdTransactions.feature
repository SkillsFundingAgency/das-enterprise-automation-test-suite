Feature: ApiGetAccountTransactionsHashedAccountIdTransactions

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_06_ApiGetAccountTransactionsHashedAccountIdTransactions
	Then endpoint /accounts/{hashedAccountId}/transactions  can be accessed
	
