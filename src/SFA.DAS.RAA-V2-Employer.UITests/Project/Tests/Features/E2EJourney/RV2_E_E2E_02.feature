Feature: RV2_E_E2E_02

@raa-v2
@raa-v2e
@v2_e2e
@v2e_e2e
@regression
Scenario: RV2_E_E2E_02 - Create vacancy with trading name, Approve, Apply and make Application Unsuccessful
	Given the Employer creates a vacancy by using a trading name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Employer can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA