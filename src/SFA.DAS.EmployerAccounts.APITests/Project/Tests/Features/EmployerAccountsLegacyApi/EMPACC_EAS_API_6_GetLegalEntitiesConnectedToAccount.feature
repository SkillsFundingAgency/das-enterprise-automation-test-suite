Feature: GetLegalEntitiesConnectedToAccount

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_6_GetLegalEntitiesConnectedToAccount
	Then endpoint api/accounts/{accountId}/legalentities can be accessed