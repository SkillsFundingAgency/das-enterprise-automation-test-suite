Feature: RV2_E_E2E_01

@raa-v2
@clonevacancy
@regression
Scenario: RV2_E_CL_01 - Clone a vacancy, Approve, Apply and make Application Successful
	Given the Employer clones and creates a vacancy
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
	Then Employer can make the application successful
	And the status of the Application is shown as 'successful' in FAA