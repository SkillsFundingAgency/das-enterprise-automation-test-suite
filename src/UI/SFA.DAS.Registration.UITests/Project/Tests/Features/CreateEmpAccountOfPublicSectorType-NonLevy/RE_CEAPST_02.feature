Feature: RE_CEAPST_02

@regression
@registration
@addnonlevyfunds
@addanothernonlevypayedetails
Scenario: RE_CEAPST_02_Create an Employer Account with Public Sector Type Org and create another Employer Account with the Same Org
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	And the Employer logsout of the Account
	Then an Employer is able to create another Account with the same PublicSector Type Org but with a different PAYE