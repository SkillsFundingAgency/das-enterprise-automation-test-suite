Feature: RE_CEAPST_01

@regression
@registration
@addpayedetails
Scenario: RE_CEAPST_01_Create an Employer Account with Public Sector Type Org and verify Adding the same Org again
	When an User Account is created
	And the User adds PAYE details
	And adds PublicSector Type Organisation details
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed
	When the Employer initiates adding another same Org of PublicSector Type again
	Then 'Already added' message should be shown to the User