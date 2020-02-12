Feature: RE_CEACT_01

@regression
@registration
@addpayedetails
Scenario: RE_CEACT_01_Create an Employer Account with CompanyType Organisation and Add another Org of PublicSector Type
	When an User Account is created
	And the User adds PAYE details
	And adds Company Type Organisation details
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed
	When the Employer initiates adding another Org of PublicSector Type
	Then the new Org added is shown in the Account Organisations list