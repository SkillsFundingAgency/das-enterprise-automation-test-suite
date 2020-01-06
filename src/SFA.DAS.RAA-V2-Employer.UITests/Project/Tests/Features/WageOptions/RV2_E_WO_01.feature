Feature: RV2_E_WO_01

@raa-v2
@regression
Scenario: RV2_E_WO_01 - Employer verifies ‘National Minimum Wage' option 
        When Employer selects 'National Minimum Wage' in the first part of the journey
        Then the Employer verify 'National Minimum Wage' the wage option selected in the Preview page