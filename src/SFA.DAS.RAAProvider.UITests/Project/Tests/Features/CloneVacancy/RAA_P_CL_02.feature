Feature: RAA_P_CL_02

@raa
@raaprovider
@clonevacancy
@regression
Scenario: RAA_P_CL_02 - Clone an advert, Approve, Apply and make Application Unsuccessful
	Given the Provider clones and creates an advert
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
