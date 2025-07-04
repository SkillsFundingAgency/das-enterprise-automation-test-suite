@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Feature: RAA_P_E2E_S01
As a provider want to be be able to select single applicant, share with employer and make application successful and unsuccessful

Scenario: RAA_P_E2E_S01 - Create vacancy with registered name, Approve, Apply, share single Application and make it successful
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application shared
	Then Provider can make the application successful
	And the status of the Application is shown as 'successful' in FAA

Scenario: RAA_P_E2E_S02 - Create vacancy with registered name, Approve, Apply, share single Application and make it unsuccessful
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application shared
	Then Provider can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
