Feature: RE_CMEA_01

@regression
@registration
@addpayedetails
@addanothernonlevypayedetails
Scenario: RE_CMEA_01_Create an Employer Account and Add another Account for the same login
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then the Employer is able to add another Account to the same user login
	And the Employer is able to switch between the Accounts