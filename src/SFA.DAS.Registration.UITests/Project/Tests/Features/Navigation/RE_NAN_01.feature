Feature: RE_NAN_01

@regression
@registration
@addpayedetails
@addlevyfunds
Scenario: RE_NAN_01_Verify Navigation for New User Account
	Given The User creates NonLevyEmployer account and sign an agreement
	Then the Employer Home page is displayed
	And EI link is visible on the Employer Home page
