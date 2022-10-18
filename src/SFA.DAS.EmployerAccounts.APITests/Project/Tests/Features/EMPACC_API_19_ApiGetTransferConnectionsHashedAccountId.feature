Feature: ApiGetTransferConnectionsHashedAccountId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_19_ApiGetTransferConnectionsHashedAccountId
	Then endpoint /api/accounts/{hashedAccountId}/transfers/connections can be accessed
	Then endpoint /api/accounts/internal/{accountId}/transfers/connections can be accessed