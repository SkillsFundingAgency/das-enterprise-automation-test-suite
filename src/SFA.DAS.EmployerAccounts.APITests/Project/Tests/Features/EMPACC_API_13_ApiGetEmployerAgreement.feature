Feature: ApiGetEmployerAgreement

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_13_ApiGetEmployerAgreement
	Then endpoint /api/accounts/{hashedAccountId}/legalEntities/{hashedlegalEntityId}/agreements/{agreementId} can be accessed