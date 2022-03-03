Feature: RV2_E_AV_01

@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_AV_01 - Create anonymous advert, Approve, Apply
	Given the Employer creates an anonymous advert
	When the Reviewer Approves the vacancy
	Then the Applicant can apply for a Vacancy in FAA