Feature: AP_NL_E2E_03_NonLevyE2EJourneyThree

@approvals
@regression
Scenario: AP_NL_E2E_03 Provider approves and then the non-levy Employer approves the cohort
	Given An Employer has given create reservation permission to a provider
    When Provider creates a reservation and adds 2 apprentices and approves the cohort and sends to Employer to approve
	Then the Employer approves the cohorts