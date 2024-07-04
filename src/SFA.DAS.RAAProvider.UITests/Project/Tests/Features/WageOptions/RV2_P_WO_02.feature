Feature: RAA_P_WO_02

@raa
@raaprovider
@regression
Scenario: RAA_P_WO_02 - Provider verifies ‘National Minimum Wage For Apprentices' option 
        When Provider selects 'National Minimum Wage For Apprentices' in the first part of the journey
        Then the Provider verify 'National Minimum Wage For Apprentices' the wage option selected in the Preview page