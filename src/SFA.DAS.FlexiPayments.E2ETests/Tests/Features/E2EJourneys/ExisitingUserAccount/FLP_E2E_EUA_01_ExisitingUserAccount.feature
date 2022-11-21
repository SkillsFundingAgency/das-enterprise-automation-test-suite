Feature: FLP_E2E_EUA_01_ExisitingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_01 Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing Levy Account
	And the learner has training code "154", date of birth "2004/05/27", start date "2023/08/01", end date "2024/07/31" and agreed price "15000"
	When the Employer approves 1 cohort and sends to provider
	And the provider adds Ulns and Opt the learners into the pilot
	Then Provider is able to successfully approve the cohort
