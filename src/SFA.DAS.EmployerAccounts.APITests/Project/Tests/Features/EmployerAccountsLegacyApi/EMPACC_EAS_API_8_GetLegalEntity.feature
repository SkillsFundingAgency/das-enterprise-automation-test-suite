Feature: GetLegalEntity

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_8_GetLegalEntity
	Then endpoint api/accounts/{hashedAccountId}/legalentities/{legalEntityId} from legacy accounts api can be accessed