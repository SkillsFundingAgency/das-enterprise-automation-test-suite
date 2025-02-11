Feature: GetInternalAccountUsers

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_4_GetInternalAccountUsers
	Then endpoint /api/accounts/internal/{accountId}/users from legacy accounts api can be accessed