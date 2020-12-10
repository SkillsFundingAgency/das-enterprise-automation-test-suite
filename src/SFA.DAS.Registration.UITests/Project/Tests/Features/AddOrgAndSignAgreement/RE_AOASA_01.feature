Feature: RE_AOASA_01

@regression
@registration
@addnonlevyfunds
Scenario: RE_AOASA_01_Verify Employer Sign Agreement journey when One and Many Orgs Agreements are not signed
	Given an Employer Account with PublicSector Type Org is created and agreement is Signed
	When the Employer adds another Org to the Account
	Then the Sign Agreement journey from the Account home page shows Accepted Agreement page
	When the Employer adds two additional Orgs to the Account
	Then the Sign Agreement journey from the Account home page shows Accepted Agreement page with link to review other pending agreements