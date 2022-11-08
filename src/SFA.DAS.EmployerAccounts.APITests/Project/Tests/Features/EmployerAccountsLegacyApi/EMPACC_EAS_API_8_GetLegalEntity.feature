Feature: GetLegalEntity

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_8_GetLegalEntity
	Then endpoint api/accounts/{accountId}/legalentities/{legalEntityId} can be accessed