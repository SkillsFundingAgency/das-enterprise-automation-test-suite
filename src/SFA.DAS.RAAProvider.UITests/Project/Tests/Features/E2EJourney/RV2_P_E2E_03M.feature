Feature: RV2_P_E2E_03M

@raa-v2
@raa-v2p
@v2_e2e
@v2p_e2e
@regression
Scenario: RV2_P_E2E_03M - Create vacancy by entering data for Optional fields, Approve, Apply and make Multiply Applications Unsuccessful
	Given the Provider creates a vacancy by entering all the Optional fields
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then Provider can make multiple applications unsuccessful
