Feature: RAA_E_AV_03

@raa
@raaemployer
@regression
Scenario: RAA_E_AV_03 - Create advert with multiple work location, Approve, Apply
	Given the Employer creates an advert with "multiple" work location
	When the Reviewer Approves the vacancy
	Then the Applicant can apply for a Vacancy with multiple locations in FAA
