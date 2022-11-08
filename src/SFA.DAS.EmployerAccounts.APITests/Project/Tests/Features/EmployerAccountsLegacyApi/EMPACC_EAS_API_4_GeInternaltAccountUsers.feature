Feature: GeInternaltAccountUsers

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_4_GeInternaltAccountUsers
	Then endpoint /api/accounts/{accountId}/users can be accessed