Feature: ExistingUserAccountE2EJourneyThree

@regression
@e2escenarios
Scenario: E2E3 Provider adds apprentices and approves then employer approves cohort
	Given the Employer login using existing levy account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices approves them and sends to employer to approve
	Then the Employer approves the cohorts