Feature: Live_EAS_01

@regression
@livesmoketest
Scenario: Live_EAS_01 Login for Existing Levy Account and Navigation to Saved favourites, Help and all Settings pages
	Given the Employer logins using existing Levy Account
	Then Employer is able to navigate to all the link under Settings
	And Employer is able to navigate to Help Page