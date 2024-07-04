Feature: RV2_P_E2E_01

@raa-v2
@raa-v2p
@v2_e2e
@v2p_e2e
@regression
Scenario: RV2_P_E2E_01 - Create vacancy with registered name, Approve, Apply and make Application Successful
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application successful
	And the status of the Application is shown as 'successful' in FAA