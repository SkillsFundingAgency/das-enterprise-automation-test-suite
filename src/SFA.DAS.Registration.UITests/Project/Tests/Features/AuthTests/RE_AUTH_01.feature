Feature: RE_AUTH_01

@authtests
@ignore
Scenario: RE_AUTH_01_Verify
	Given registration urls are read from storage container
	Then a valid user can not access different account
	And an unauthorised user can not access the service
	