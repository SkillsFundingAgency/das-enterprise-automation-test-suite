Feature: AP_NL_E2E_03_NonLevyE2EJourneyTwo

@regression
@non-levy
Scenario: AP_NL_E2E_02 NE2E2 Non Levy Employer sends cohort to provider for review then provider approves then employer approves
	Given the Employer login using existing eoi account
	When the Employer uses the reservation and adds 2 cohort and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer approves the cohorts