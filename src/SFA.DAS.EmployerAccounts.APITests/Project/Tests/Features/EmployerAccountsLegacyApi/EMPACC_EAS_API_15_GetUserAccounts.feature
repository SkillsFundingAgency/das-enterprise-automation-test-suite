Feature: GetUserAccounts
@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_15_GetUserAccounts
	Then endpoint api/user/{userRef}/accounts from legacy accounts api can be accessed