@regression
@registration
@addnonlevyfunds
Feature: RE_AORN_04

Scenario: RE_AORN_04_Validate AORN route PAYE scheme details page error content
	Given an User Account is created
	When the User is on the 'Add a PAYE Scheme' page
	Then choosing to Continue with BlankAornAndBlankPaye displays relevant Error text
	And choosing to Continue with BlankAornValidPaye displays relevant Error text
	And choosing to Continue with BlankPayeValidAorn displays relevant Error text
	And choosing to Continue with InvalidAornAndInvalidPaye displays relevant Error text