Feature: RV2_E_CVMD_01

@raa-v2	
@raa-v2e
@regression
Scenario: RV2_E_CVMD_01 - Create Vacancy with missing mandatory details
        Given the Employer completes the first part of the journey
        When the Employer submits the vacancy
        Then submission errors displayed for not completing the mandatory information
