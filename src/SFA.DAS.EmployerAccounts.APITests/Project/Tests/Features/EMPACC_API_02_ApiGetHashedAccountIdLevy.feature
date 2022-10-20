Feature: ApiGetHashedAccountIdLevy

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_02_ApiGetHashedAccountIdLevy
	Then endpoint /accounts/{hashedAccountId}/levy can be accessed
