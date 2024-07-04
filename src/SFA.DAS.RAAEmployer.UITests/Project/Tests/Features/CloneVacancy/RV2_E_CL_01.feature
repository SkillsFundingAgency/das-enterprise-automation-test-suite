Feature: RAA_E_CL_01

@raa
@raaemployer
@clonevacancy
@regression
Scenario: RAA_E_CL_01 - Clone an advert, Approve, Apply and make Application Successful
	Given the Employer clones and creates an advert
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Employer can make the application successful
	And the status of the Application is shown as 'successful' in FAA