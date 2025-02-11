Feature: EmpFin_Api_03_GetLevyForPeriod

@api
@employerfinanceapi
@regression
@innerapi
Scenario: GetLevyForPeriod
	Then endpoint api/accounts/{hashedAccountId}/transactions/GetTransactions can be accessed
