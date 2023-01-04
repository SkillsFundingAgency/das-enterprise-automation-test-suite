Feature: ApiGetLegalEntitiesHashedAccountIdLegalEntityId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_16_ApiGetLegalEntitiesHashedAccountIdLegalEntityId
	Then endpoint /api/accounts/{hashedAccountId}/legalentities/{legalEntityId} can be accessed