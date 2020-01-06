Feature: RV2_E_CVS_01

@raa-v2		
@raa-v2e
@regression		
Scenario: RV2_E_CVS_01 - Create, Approve and Close the vacancy
	Given the Employer can create a vacancy by entering all the Optional fields
	And the Reviewer Approves the vacancy
	Then the Employer can close the vacancy
