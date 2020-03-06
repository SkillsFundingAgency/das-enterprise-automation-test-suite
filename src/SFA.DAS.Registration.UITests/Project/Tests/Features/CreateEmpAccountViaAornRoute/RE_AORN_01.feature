Feature: RE_AORN_01

@regression
@registration
@addpayedetails
Scenario: RE_AORN_01A_Create an Employer Account through AORN route with paye details attached to a Single Organisation
	Given an User Account is created
	When the User adds PAYE details attached to a SingleOrg through AORN route
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed
	And 'These details are already in use' page is displayed when Another Employer tries to register the account with the same Aorn and Paye details
	And 'Ways to add your PAYE Scheme' page is displayed when Employer clicks on 'Use different details' button
	And 'Ways to add your PAYE Scheme' page is displayed when Employer clicks on Back link on the 'PAYE scheme already in use' page

@regression
@registration
@addpayedetails
Scenario: RE_AORN_01B_Create an Employer Account through AORN route with paye details attached to a Multiple Organisations
	Given an User Account is created
	When the User adds PAYE details attached to a MultiOrg through AORN route
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed