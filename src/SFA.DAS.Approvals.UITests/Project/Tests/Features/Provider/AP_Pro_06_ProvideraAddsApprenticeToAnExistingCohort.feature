@approvals
Feature: AP_Pro_06_ProvideraAddsApprenticeToAnExistingCohort
	

@regression
Scenario: AP_Pro_06_Provider Adds Apprentice To An Existing Cohort Journey
	Given the Provider has some apprentices in ready to review and draft status
	And the Provider navigates to Choose a cohort page via the Home page
	Then the Provider should only see apprentices with status Draft or Ready to review excluding apprentices related to change of party
	And User should be able to add or edit apprentice details on any cohort
