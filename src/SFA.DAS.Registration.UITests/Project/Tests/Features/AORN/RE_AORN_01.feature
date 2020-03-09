@regression
@registration
@addpayedetails
Feature: RE_AORN_01

Scenario: RE_AORN_01_Create an Employer Account through AORN route with paye details attached to a Single Organisation
	Given an User Account is created
	When the User adds PAYE details attached to a SingleOrg through AORN route
	Then the Employer is able to Sign the Agreement and view the Home page
	And 'These details are already in use' page is displayed when Another Employer tries to register the account with the same Aorn and Paye details
	And 'Add a PAYE Scheme' page is displayed when Employer clicks on 'Use different details' button
	And 'Add a PAYE Scheme' page is displayed when Employer clicks on Back link on the 'PAYE scheme already in use' page
