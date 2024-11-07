Feature: Live_EAS_01_HomePageNavigation

@regression
@livesmoketest
Scenario: Live_EAS_01_HomePageNavigation
	Given the Employer logins using existing Levy Account
	Then the standard header should be displayed
	And the help widget can be accessed
	Then Apprentices link should direct user to Apprentices page
	And Your apprenticeship adverts link should direct user to Create an advert page
	And Your training providers link should direct user to Your training providers page
	And Your finances link should direct user to Finance page	
	And Your transfers link should lead user to Manage transfers pages	
	And Your organisations and agreements link should direct user to Your organisations and agreements page	
	And Your team link should direct user to Your team page	
	And PAYE schemes link should direct user to PAYE schemes page	
	And Find apprenticeship training link should direct user to Apprenticeship training courses page
