Feature: RP_CA_01

@roatpapplycreateaccount
@roatp
@regression
Scenario: RP_CA_01_Create_Account
Given an apply user creates an account
Then an account is created
	Then the Apply User is able to Create an Account
	