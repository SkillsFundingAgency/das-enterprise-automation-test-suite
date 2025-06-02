Feature: RAA_E_E2E_01

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_E2E_01 - Create an advert with registered name, Approve, Apply and make Application Successful
	Given the Employer creates an advert by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the 'employer' receives 'new application' email notification
	Then Employer can make the application successful
	And the status of the Application is shown as 'successful' in FAA 