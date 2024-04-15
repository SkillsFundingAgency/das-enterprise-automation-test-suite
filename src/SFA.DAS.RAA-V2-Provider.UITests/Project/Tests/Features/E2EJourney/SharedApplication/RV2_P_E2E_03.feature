Feature: RV2_P_E2E_03
As a provider want to be be able to select single applicant and share with employer

@raa-v2
@raa-v2p
@v2_e2e
@v2p_e2e
@regression
Scenario: RV2_P_E2E_03 - Create vacancy with registered name, Approve, Apply and share single Application
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application shared
