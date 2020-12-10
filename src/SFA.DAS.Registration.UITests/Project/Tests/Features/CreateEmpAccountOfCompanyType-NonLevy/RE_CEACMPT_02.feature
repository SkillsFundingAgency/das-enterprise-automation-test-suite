Feature: RE_CEACMPT_02

@regression
@registration
@addnonlevyfunds
Scenario: RE_CEACMPT_02_Verify Invalid PAYE and Company number entry during Employer Account creation
	When an User Account is created
	And the User adds Invalid PAYE details
	Then the 'Bad user name or password' error message is shown
	When the User adds valid PAYE details on Gateway Sign In Page
	And enters an Invalid Company number for Org search
	Then the '0 results found' message is shown