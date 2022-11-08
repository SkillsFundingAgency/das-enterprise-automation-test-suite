Feature: GetEmployerAgreement

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_5_GetEmployerAgreement
	Then endpoint api/accounts/{accountId}/legalEntities/{legalEntityId}/agreements/{agreementId}/agreement can be accessed