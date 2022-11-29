Feature: EmpFin_Api_10_AccountTransferConnections

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EmpFin_Api_10_AccountTransferConnections
	Then endpoint /api/accounts/{hashedAccountId}/transfers/connections can be accessed
	And endpoint /api/accounts/internal/{accountId}/transfers/connections can be accessed