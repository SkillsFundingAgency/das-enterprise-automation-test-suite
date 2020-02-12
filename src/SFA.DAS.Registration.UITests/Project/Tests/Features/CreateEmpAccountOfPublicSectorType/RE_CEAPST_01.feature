Feature: RE_CEAPST_01

@regression
@registration
@addpayedetails
Scenario: RE_CEAPST_01_Create an Employer Account with Public Sector Type Organisation
	When an User Account is created
	And the User adds PAYE details
	And adds PublicSector Type Organisation details
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed