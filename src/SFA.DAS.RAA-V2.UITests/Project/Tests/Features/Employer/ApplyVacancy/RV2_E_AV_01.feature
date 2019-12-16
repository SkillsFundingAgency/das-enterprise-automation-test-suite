Feature: RV2_E_AV_01

@raa-v2		
@regression		
Scenario: RV2_E_AV_01 - Create anonymous vacancy, Approve, Apply 
Given the Employer creates an anonymous vacancy
	And the Reviewer Approves the vacancy
	When the Applicant applies for a Vacancy in FAA
