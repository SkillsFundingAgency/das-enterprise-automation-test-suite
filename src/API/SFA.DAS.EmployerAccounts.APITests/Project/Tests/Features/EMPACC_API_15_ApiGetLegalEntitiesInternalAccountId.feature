Feature:ApiGetLegalEntitiesInternalAccountId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_15_ApiGetLegalEntitiesInternalAccountId
	Then endpoint /api/accounts/{AccountId}/legalentities can be accessed