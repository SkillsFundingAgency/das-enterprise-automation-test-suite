Feature: AP_NL_E2E_01_NonLevyE2EJourneyOne

@regression
@non-levy
Scenario: AP_NL_E2E_01 Non Levy Employer sends an approved cohort then provider approves the cohort
	Given the Employer login using existing eoi account
	When the Employer uses the reservation to create and approve 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts