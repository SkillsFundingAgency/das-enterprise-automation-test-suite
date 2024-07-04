Feature: RAA_P_E2E_02

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_02 - Create vacancy by entering data for Optional fields, Approve, Apply and make Application Unsuccessful
	Given the Provider creates a vacancy by entering all the Optional fields
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA