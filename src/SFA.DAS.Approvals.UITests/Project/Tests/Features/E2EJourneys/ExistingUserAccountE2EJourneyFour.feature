@approvals
Feature: ExistingUserAccountE2EJourneyFour

@regression
@e2escenarios
Scenario: E2E4 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer login using existing levy account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices and sends to employer to review
	When the Employer approves the cohort and sends to provider
	Then the provider approves the cohorts