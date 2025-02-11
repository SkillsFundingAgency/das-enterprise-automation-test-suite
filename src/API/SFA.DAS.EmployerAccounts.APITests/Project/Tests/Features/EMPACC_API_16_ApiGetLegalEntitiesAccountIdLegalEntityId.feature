Feature: ApiGetLegalEntitiesAccountIdLegalEntityId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_16_ApiGetLegalEntitiesAccountIdLegalEntityId
	Then endpoint /api/accounts/{AccountId}/legalentities/{legalEntityId} can be accessed