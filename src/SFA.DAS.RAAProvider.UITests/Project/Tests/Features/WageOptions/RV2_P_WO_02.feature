Feature: RV2_P_WO_02

@raa-v2
@raa-v2p
@regression
Scenario: RV2_P_WO_02 - Provider verifies ‘National Minimum Wage For Apprentices' option 
        When Provider selects 'National Minimum Wage For Apprentices' in the first part of the journey
        Then the Provider verify 'National Minimum Wage For Apprentices' the wage option selected in the Preview page