Feature: RV2_P_FV_01

@raa-v2	
@raa-v2p
@regression	
Scenario: RV2_P_FV_01 - Provider views Rejected vacancies
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Refer the vacancy
	Then Provider can view the refered vacancy
