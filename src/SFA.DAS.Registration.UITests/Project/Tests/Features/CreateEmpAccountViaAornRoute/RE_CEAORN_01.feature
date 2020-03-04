Feature: RE_CEAORN_01
#AORN - Accounts Office Reference Number

@regression
@registration
@addpayedetails
Scenario: RE_CEAORN_01_Create an Employer Account with Public Sector Type Org and verify Adding the same Org again
	Given an User Account is created
	When the User adds PAYE details through AORN route
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed