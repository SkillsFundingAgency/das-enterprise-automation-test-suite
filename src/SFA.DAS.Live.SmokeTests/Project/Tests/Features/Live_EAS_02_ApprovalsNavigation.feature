Feature: Live_EAS_02_ApprovalsNavigation

@regression
@livesmoketest
Scenario: Live_EAS_02_ApprovalsNavigation
	Given the Employer logins using existing Levy Account
	When employer navigates to Apprentices tab in the nav bar
	Then Add an apprentice link should direct user to Add an apprentice page
	And Apprentice requests link should direct user to Apprentice requests page
    And Manage your apprentices link should direct user to Manage your apprentices page
	