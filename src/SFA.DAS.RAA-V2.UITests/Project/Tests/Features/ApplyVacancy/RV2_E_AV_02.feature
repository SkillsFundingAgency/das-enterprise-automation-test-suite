Feature: RV2_E_AV_02

@raa-v2
@regression
Scenario: RV2_E_AV_02 - Create vacancy with different work location, Approve, Apply
	Given the Employer creates a vacancy by selecting different work location
	When the Reviewer Approves the vacancy
	Then the Applicant can apply for a Vacancy in FAA