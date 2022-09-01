Feature: RAT_P_E2E_01

A short summary of the feature

@raa-v2	
@raa-v2p		
@rat-p	
@regression		
Scenario: RAT_P_E2E_01 - Create vacancy with registered name, Approve, Apply and make Application Successful
	Given the Provider creates traineeship vacancy through View all your traineeship vacancies page
	And the Reviewer Approves the vacancy
	When the Applicant can apply for the Vacancy in FAT
	Then Provider can make the application successful
	And the status of the Application is shown as 'successful' in FAA
