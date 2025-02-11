Feature: RAA_E_E2E_03

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_E2E_03 - Create an advert with trading name, Approve, Apply and mark Application as In Review
	Given the Employer creates an anonymous advert
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Employer can mark applicant as In Review
