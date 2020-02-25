Feature: RE_CEAPST_01

@regression
@registration
@addpayedetails
Scenario: RE_CEAPST_01_Create an Employer Account with Public Sector Type Org and verify Adding the same Org again
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	When the Employer initiates adding another same Org of PublicSector Type again
	Then 'Already added' message is shown to the User