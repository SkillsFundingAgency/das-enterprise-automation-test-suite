Feature: ApiGetAccountPayeSchemesHashedAccountIdPayeSchemes

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_04_ApiGetAccountPayeSchemesHashedAccountIdPayeSchemes
	Then endpoint /api/accounts/{hashedAccountId}/payeschemes can be accessed