Feature: RAA_E_E2E_03F

@raa
@raaemployer
@raae2e
@raaemployere2e
@regression
Scenario: RAA_E_E2E_03F - Create a foundation advert with trading name, Approve and check ineligible applicant cannot apply	
	Given the Employer creates a foundation advert by using a trading name
	When the Reviewer Approves the vacancy
	Then the ineligible applicant can not apply for a foundation vacancy in FAA