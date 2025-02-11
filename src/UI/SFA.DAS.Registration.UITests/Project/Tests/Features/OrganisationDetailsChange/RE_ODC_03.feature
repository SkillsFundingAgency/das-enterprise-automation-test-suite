Feature: RE_ODC_03

@regression
@registration
@addnonlevyfunds
Scenario: RE_ODC_03_Create an Employer Account with PublicSector Type Org and verify OrgName change scenario
	Given an Employer Account with PublicSector Type Org is created and agreement is Signed
	When the Employer reviews Agreement page
	Then the 'Update these details' link is not displayed for PublicSector Type Org