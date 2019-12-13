Feature: RV2_E_E2E_01

@raa-v2		
@regression		
Scenario: RV2_E_E2E_01 - Create vacancy with registered name, Approve, Apply and make Application Successful		
Given the Employer creates a vacancy by using a registered name
And the Reviewer Approves the vacancy
When the Applicant apply for a Vacancy in FAA 'No','No','No'
Then Employer can make the application successful
Then the Application status should be successful

