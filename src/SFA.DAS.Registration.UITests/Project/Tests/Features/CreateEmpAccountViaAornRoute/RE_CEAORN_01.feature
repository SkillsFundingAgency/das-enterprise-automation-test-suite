Feature: RE_CEAORN_01

@regression
@registration
@addpayedetails
Scenario: RE_CEAORN_01_Create an Employer Account through AORN route with paye details attached to a Single Organisation
	Given an User Account is created
	When the User adds PAYE details attached to a SingleOrg through AORN route 
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed