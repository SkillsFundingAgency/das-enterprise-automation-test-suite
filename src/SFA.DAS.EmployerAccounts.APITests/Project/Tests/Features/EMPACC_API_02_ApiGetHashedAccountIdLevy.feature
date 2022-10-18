Feature: ApiGetHashedAccountIdLevy

@api
@employeraccountsapi
@regression
@innerapi
Scenario: EMPACC_API_02_ApiGetHashedAccountIdLevy
	Then Check with Raj  /accounts/{hashedAccountId}/levy 
