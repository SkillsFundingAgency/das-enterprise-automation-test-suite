Feature: RAA_P_E2E_01

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_01 - Create vacancy with registered name, Approve, Apply, receive email notifications and make Application Successful
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the 'provider' receives 'new application' email notification
	And the 'applicant' receives 'new application' email notification
	And Provider can make the application successful
	And the status of the Application is shown as 'successful' in FAA
	And the 'applicant' receives 'successful application' email notification