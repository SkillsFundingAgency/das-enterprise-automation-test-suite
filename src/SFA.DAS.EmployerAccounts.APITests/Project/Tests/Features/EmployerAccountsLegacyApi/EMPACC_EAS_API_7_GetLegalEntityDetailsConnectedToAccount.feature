Feature: GetLegalEntityDetailsConnectedToAccount

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_EAS_API_7_GetLegalEntityDetailsConnectedToAccount
	Then endpoint api/accounts/{accountId}/legalentities?includeDetails=true can be accessed