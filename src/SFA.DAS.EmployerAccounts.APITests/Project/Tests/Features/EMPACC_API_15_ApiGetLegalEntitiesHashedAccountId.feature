Feature: ApiGetLegalEntitiesHashedAccountId

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_15_ApiGetLegalEntitiesHashedAccountId
	Then endpoint /api/accounts/{hashedAccountId}/legalentities can be accessed