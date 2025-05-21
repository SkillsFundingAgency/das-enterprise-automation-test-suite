Feature: RAA_P_E2E_S02

As a provider want to be be able to select by multiple applicant link and share with employer

@raa
@raaprovider
@raae2e
@raaprovidere2e
@regression
Scenario: RAA_P_E2E_S02 - Create vacancy with registered name, Approve, Apply, share multiple Application and make them unsuccessful
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When multiple Applicants can apply for a Vacancy in FAA
	Then Provider can share multiple applications 
	Then Provider can make multiple applications unsuccessful
