Feature: ApiGetAccountPayeSchemesHashedAccountIdPayeSchemes

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_04_ApiGetAccountPayeSchemesHashedAccountIdPayeSchemes
	Then endpoint /api/accounts/{accountId}/payeschemes can be accessed