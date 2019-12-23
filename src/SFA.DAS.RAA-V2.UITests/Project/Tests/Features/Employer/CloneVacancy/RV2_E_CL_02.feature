Feature: RV2_E_CL_02

@raa-v2
@clonevacancy
@regression
Scenario: RV2_E_CL_02 - Clone a vacancy, Approve, Apply and make Application Unsuccessful
	Given the Employer clones and creates a vacancy
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
	Then Employer can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA