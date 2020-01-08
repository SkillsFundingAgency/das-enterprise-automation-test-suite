Feature: RV2_E_CL_03

@raa-v2
@raa-v2e
@clonevacancy
@regression		
Scenario: RV2_E_CL_03 - Clone, Approve and Close the vacancy
	Given the Employer clones and creates a vacancy
	And the Reviewer Approves the vacancy
	Then the Employer can close the vacancy
