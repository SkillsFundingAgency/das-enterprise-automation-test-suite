Feature: GetLegalEntityDetailsConnectedToAccount

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_7_GetLegalEntityDetailsConnectedToAccount
	Then endpoint api/accounts/{hashedAccountId}/legalentities?includeDetails=true from legacy accounts api can be accessed