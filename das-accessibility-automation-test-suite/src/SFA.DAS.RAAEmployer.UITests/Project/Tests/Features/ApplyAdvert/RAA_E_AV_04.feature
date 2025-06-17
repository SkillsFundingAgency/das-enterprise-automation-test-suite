Feature: RAA_E_AV_04

@raa
@raaemployer
@regression
Scenario: RAA_E_AV_04 - Create advert with nationwide locations, Approve, Apply
	Given the Employer creates an advert with "national" work location
	When the Reviewer Approves the vacancy
	Then the Applicant can apply for a Vacancy in FAA
