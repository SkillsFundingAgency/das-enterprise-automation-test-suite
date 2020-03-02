Feature: RE_RAO_01

@regression
@registration
@addpayedetails
Scenario: RE_RAO_01_Verify Employer is Not allowed to Remove an Org when there is only one in the Account and Allowed to Remove a second Org added
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	Then the Employer is Not allowed to Remove the first Org added
	When the Employer initiates adding another Org of Company Type
	Then the new Org added is shown in the Account Organisations list
	And Emlployer is Allowed to remove the second Org added from the account 