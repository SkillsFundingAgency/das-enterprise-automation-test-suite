Feature: RE_CEACMPT_01

@regression
@registration
@addpayedetails
Scenario: RE_CEACMPT_01_Create an Employer Account with CompanyType Organisation and Add another Org of PublicSector Type
	When an Employer Account with Company Type Org is created and agreement is Signed
	When the Employer initiates adding another Org of PublicSector Type
	Then the new Org added is shown in the Account Organisations list