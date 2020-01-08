Feature: RV2_E_DV_03

@raa-v2	
@raa-v2e
@regression	
Scenario: RV2_E_DV_03 - Delete draft vacancy
Given the Employer completes the first part of the journey
When the Employer saves the vacancy as a draft
Then the Employer can cancel deleting the draft vacancy
Then the Employer is able to delete the draft vacancy
