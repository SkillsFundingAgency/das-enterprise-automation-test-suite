# ToBeMigrated: this scenario will be deleted once 'Add apprentice details' option is removed from Employer side


@approvals
Feature: AP_NL_E2E_01_NonLevyE2EJourneyOne

@regression
@non-levy
@reservation
Scenario: AP_NL_E2E_01 Non Levy Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing NonLevy Account
	When the Employer creates 2 reservations
	Then the employer uses the reservation to add an apprentice
	And the employer uses the second reservation to add another apprentice and approve the cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts