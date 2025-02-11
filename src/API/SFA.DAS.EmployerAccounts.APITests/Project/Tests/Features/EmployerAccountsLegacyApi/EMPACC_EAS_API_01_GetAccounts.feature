Feature: GetAccounts

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_01_GetAccounts
	Then endpoint api/accounts/{hashedAccountId} from legacy accounts api can be accessed
	
