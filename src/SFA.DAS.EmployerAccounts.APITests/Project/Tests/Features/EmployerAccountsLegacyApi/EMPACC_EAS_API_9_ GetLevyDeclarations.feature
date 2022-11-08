Feature: GetLevyDeclarations

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_9_ GetLevyDeclarations
	Then endpoint api/accounts/{accountId}/levy can be accessed