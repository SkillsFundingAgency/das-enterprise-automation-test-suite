Feature: RE_Tasks_01

@regression
@registration
@addpayedetails
Scenario: RE_Tasks_01_Create an Employer Account with Public Sector Type Org and verify Tasks link
	When an Employer Account with PublicSector Type Org is created and agreement is Signed
	Then 'Start adding apprentices now' task link is displayed under Tasks pane