Feature: RAA_E_E2E_02

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_E2E_02 - Create an advert with trading name, Approve, Apply, make Application Unsuccessful and receive email notification
	Given the Employer creates an advert by using a trading name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Employer can make the application unsuccessful
	And the status of the Application is shown as 'unsuccessful' in FAA
	And the 'applicant' receives 'unsuccessful application' email notification