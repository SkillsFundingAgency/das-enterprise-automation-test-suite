Feature: RV2_P_E2E_04

@raa-v2
@raa-v2p
@v2_e2e
@v2p_e2e
@regression
Scenario: RV2_P_E2E_04 - Create vacancy by entering data for Optional fields, Approve, Apply and mark Application as Interviewing with Employer
	Given the Provider creates a vacancy by entering all the Optional fields
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make the application interviewing with Employer
