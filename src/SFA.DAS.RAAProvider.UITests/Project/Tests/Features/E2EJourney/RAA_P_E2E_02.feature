Feature: RAA_P_E2E_02

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_02 - Create vacancy by entering data for Optional fields, Approve, Apply, make Application Unsuccessful and receive email notification
	Given the Provider creates a vacancy with "national" work locations by entering all the Optional fields and "both" additional questions
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
	And the 'applicant' receives 'unsuccessful application' email notification