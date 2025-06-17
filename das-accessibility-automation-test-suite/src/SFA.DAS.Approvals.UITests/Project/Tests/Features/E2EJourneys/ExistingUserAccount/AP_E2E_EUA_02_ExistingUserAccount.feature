@approvals
Feature: AP_E2E_EUA_02_ExistingUserAccount

@regression
@e2escenarios
Scenario: AP_E2E_EUA_02 Employer sends cohort to provider for review then provider approves then employer approves
	Given the Employer logins using existing Levy Account
	And Employer adds 2 apprentices to a new cohort
	Then the Employer sees the cohort in Draft with status of New request
	When the Employer sends new cohort to provider
	Then the Employer sees the cohort in With training providers with status of Under review with provider
	When the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer sees the cohort in Ready to review with status of Ready for approval
	And the Employer approves the cohorts
	