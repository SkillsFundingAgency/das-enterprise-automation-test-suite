Feature: RAA_E_E2E_04

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_E2E_04 - Create an advert with trading name, Approve, Apply and and mark Application as Interviewing
	Given the Employer creates an advert by using a trading name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Employer can mark the application as interviewing 