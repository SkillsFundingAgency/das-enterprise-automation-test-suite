Feature: RV2_E_CVS_02

@raa-v2		
@raa-v2e
@regression		
Scenario: RV2_E_CVS_02 - Create, Approve and Edit the vacancy
	Given the Employer creates a vacancy by using a trading name
	And the Reviewer Approves the vacancy
	Then the Employer can edit the vacancy
