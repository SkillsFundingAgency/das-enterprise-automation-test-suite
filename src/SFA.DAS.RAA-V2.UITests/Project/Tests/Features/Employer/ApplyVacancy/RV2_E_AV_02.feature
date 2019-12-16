Feature: RV2_E_AV_02

@raa-v2		
@regression		
Scenario: RV2_E_AV_02 - Create vacancy with different work location, Approve, Apply
Given the Employer creates a vacancy by selecting different work location
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
	Then the Employer can create a vacancy by selecting different work location
