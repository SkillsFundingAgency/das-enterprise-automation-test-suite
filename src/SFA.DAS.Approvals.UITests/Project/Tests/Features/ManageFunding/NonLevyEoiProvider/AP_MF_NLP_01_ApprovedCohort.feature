Feature: AP_MF_NLP_01_ApprovedCohort

@approvals
Scenario: AP_MF_NLP_01 Provider approves and then the non-levy EOI Employer approves the cohort
	Given An Employer has given create reservation permission to a provider
    When Provider creates a reservation and adds 2 apprentices and approves the cohort and sends to Employer to approve
	Then the Employer approves the cohorts