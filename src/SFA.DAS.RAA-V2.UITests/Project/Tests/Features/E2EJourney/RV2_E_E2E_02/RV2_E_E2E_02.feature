Feature: RV2_E_E2E_02

@raa-v2		
@regression		
Scenario: RV2_E_E2E_01 - Create vacancy with trading name, Approve, Apply and make Application Unsuccessful		
	Given the Employer creates a vacancy by using a trading name
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
	Then Employer can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA