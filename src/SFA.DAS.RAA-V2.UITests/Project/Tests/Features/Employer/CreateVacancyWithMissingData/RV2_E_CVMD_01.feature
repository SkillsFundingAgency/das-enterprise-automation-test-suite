Feature: RV2_E_CVMD_01

@raa-v2	
@regression
Scenario: RV2_E_CVMD_01 - Create Vacancy with missing mandatory details
Given the Employer completes the first part of the journey
When the Employer submits the vacancy
Then error messages are displayed
