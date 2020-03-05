Feature: RE_CEAORN_02

@regression
@registration
@addpayedetails
Scenario: RE_CEAORN_02_Create an Employer Account through AORN route with paye details attached to a Multiple Organisations
	Given an User Account is created
	When the User adds PAYE details attached to a MultiOrg through AORN route 
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed