Feature: RE_UnlockAcc_01

@regression
@registration
@addnonlevyfunds
Scenario: RE_UnlockAcc_01_Verify Unlock Account scenario
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer Account is locked with 3 incorrect password attempts
	And Employer is able to Unlock the Account