Feature: EmpFin_Api_04_GetTransactionSummary

@api
@employerfinanceapi
@regression
@innerapi
Scenario: GetTransactionSummary
	Then endpoint api/accounts/{accountId}/transactions can be accessed
