Feature: RE_CEAONRdb_02

@regression
@registration
@addpayedetails
Scenario: RE_CEAONRdb_02_Create an Employer Account with with CompanyType Organisation and Add another Org not in the Reference database
	Given an Employer Account with Company Type Org is created and agreement is Signed
	When the Employer initiates adding another Org of 'ManuallyAddredOrg' Type
	Then the new Org added is shown in the Account Organisations list