Feature: RV2_P_WO_03

A short summary of the feature

@raa-v2
@raa-v2p
@regression
Scenario: RV2_P_WO_03 - Provider verifies ‘Fixed Wage Type' option 
        When Provider selects 'Fixed Wage Type' in the first part of the journey
        Then the Provider verify 'Fixed Wage Type' the wage option selected in the Preview page
