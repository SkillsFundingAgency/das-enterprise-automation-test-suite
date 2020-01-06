Feature: RV2_E_OV_01

@raa-v2
@offlinevacancy
@regression
Scenario: RV2_E_OV_01 - Creates offline vacancy with disability confidence and Reviewer approves	
	Given the Employer creates an offline vacancy with disability confidence
	Then the Reviewer verifies disability confident and approves the vacancy

	