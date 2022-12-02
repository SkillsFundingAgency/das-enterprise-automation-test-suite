Feature: GetEmployerAgreement

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_5_GetEmployerAgreement
	Then endpoint api/accounts/{hashedAccountId}/legalEntities/{publicHashedLegalEntityId}/agreements/{hashedAgreementId}/agreement from legacy accounts api can be accessed