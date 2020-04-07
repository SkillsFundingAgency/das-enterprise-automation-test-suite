Feature: RE_CMEA_01

@regression
@registration
@addpayedetails
@addanothernonlevypayedetails
Scenario: RE_CMEA_01_Create an Employer Account and Add another Account for the same login
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	Then the Employer is able to add another Account with Charity Type Org to the same user login
	And the Employer is able to switch between the Accounts