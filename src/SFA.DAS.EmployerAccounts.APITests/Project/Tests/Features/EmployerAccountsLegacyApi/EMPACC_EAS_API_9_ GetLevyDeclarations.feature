Feature: GetLevyDeclarations

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_9_ GetLevyDeclarations
	Then endpoint api/accounts/{hashedAccountId}/levy from legacy accounts api can be accessed