Feature: RV2_E_E2E_01

@raa-v2
@v2_e2e
@regression		
Scenario: RV2_E_E2E_01 - Create vacancy with registered name, Approve, Apply and make Application Successful		
	Given the Employer creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
	Then Employer can make the application successful
	And the status of the Application is shown as 'successful' in FAA

