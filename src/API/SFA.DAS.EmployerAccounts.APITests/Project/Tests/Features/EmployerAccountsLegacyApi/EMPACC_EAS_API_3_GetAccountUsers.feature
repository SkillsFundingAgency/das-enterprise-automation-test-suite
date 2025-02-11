Feature: GetAccountUsers

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_3_GetAccountUsers
	Then endpoint /api/accounts/{hashedAccountId}/users from legacy accounts api can be accessed