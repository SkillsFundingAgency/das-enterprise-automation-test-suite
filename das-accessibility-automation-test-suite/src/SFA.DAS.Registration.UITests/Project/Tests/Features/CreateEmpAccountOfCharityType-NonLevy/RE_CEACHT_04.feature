Feature: RE_CEACHT_04

@regression
@registration
@addnonlevyfunds
Scenario: RE_CEACHT_04_Create an Employer Account with Charity Type Org and verify Adding the same Org again
	When an Employer Account with Charity Type Org is created and agreement is Signed
	When the Employer initiates adding same Org of Charity Type again
	Then 'Already added' message is shown to the User