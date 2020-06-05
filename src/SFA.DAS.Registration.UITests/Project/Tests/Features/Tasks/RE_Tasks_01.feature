Feature: RE_Tasks_01

@regression
@registration
@addpayedetails
Scenario: RE_Tasks_01_Create an Employer Account with Public Sector Type Org and verify Tasks link
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	Then 'Start adding apprentices now' task link is displayed under Tasks pane