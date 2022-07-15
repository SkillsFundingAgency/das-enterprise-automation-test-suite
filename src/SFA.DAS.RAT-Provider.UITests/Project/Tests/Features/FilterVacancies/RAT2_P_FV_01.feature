Feature: RAT2_P_FV_01

@rat-p
@regression
Scenario: RAT2_P_FV_01 - Provider views Rejected vacancies
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Refer the vacancy
	Then Provider can view the refered vacancy
