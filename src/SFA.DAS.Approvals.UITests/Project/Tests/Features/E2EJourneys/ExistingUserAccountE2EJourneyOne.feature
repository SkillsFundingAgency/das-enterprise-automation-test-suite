Feature: ExistingUserAccountE2EJourneyOne

@regression
@e2escenarios
Scenario: E2E1 Employer sends an approved cohort then provider approves the cohort
	Given the Employer login using existing levy account
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts