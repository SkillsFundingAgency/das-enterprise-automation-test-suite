Feature: RV2_E_DV_01

@raa-v2	
@raa-v2e
@regression	
Scenario: RV2_E_DV_01 - Employer cancels creating Vacancy
When Employer cancels after saving the title of the Vacancy
Then the vacancy is saved as a draft
