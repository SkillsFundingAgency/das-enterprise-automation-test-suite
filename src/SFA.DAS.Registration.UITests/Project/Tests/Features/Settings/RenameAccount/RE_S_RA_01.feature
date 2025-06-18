Feature: RE_S_RA_01

@regression
@registration
@addnonlevyfunds
Scenario: RE_S_RA_01_Create and Rename Employer Account
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to rename the Account