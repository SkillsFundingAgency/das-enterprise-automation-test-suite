Feature: EmpFin_Api_02_AccountMinimumSignedAgreement

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_02_AccountMinimumSignedAgreement
	Then endpoint /Accounts/{accountId}/minimum-signed-agreement-version can be accessed