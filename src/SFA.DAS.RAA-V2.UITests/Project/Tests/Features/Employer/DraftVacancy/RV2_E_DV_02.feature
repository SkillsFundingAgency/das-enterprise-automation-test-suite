Feature: RV2_E_DV_02

@raa-v2	
@regression	
Scenario: RV2_E_DV_02 - Resume Create Vacancy from Draft status
Given the Employer completes the first part of the journey
When the Employer saves the vacancy as a draft
Then Employer is able to open the draft and create the vacancy by filling the data for the second part
