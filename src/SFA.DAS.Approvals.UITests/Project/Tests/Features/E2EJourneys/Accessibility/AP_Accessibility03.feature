@accessibility
@approvals
Feature: AP_E2E_ACC_Accessibility03
Navigation journey through EAS and PAS 

@non-levy
@reservefunds
@reservation
Scenario: AP_E2E_ACC_03 Non Levy Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing NonLevy Account
	When the Employer uses the reservation to create and approve 1 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts

