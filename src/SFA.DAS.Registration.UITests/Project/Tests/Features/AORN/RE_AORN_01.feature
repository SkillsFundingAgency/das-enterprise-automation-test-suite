@regression
@registration
@addpayedetails
Feature: RE_AORN_01

Scenario: RE_AORN_01A_Create an Employer Account through AORN route with paye details attached to a Single Organisation
	Given an User Account is created
	When the User adds PAYE details attached to a SingleOrg through AORN route
	Then the Employer is able to Sign the Agreement and view the Home page
	And 'These details are already in use' page is displayed when Another Employer tries to register the account with the same Aorn and Paye details
	And 'Add a PAYE Scheme' page is displayed when Employer clicks on 'Use different details' button
	And 'Add a PAYE Scheme' page is displayed when Employer clicks on Back link on the 'PAYE scheme already in use' page

Scenario: RE_AORN_01B_Create an Employer Account through AORN route with paye details attached to a Multiple Organisations
	Given an User Account is created
	When the User adds PAYE details attached to a MultiOrg through AORN route
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed

Scenario: RE_AORN_01C_Validate AORN route check details page links
	Given an User Account is created
	When the User is on the 'Check your details' page after adding PAYE details through AORN route
	Then choosing to change the AORN number displays 'Enter your PAYE scheme details' page
	And choosing to change the PAYE scheme displays 'Enter your PAYE scheme details' page
	And choosing to change the Organisation selected displays 'Search for your Organisation' page