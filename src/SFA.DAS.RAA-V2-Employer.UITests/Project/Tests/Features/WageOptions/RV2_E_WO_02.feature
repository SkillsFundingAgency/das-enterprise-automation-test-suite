Feature: RV2_E_WO_02

@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_WO_02 - Employer verifies ‘National Minimum Wage For Apprentices' option 
        When Employer selects 'National Minimum Wage For Apprentices' in the first part of the journey
        Then the Employer verify 'National Minimum Wage For Apprentices' the wage option selected in the Preview page