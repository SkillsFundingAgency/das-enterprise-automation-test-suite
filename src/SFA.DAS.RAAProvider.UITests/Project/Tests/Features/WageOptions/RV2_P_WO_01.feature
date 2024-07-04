Feature: RAA_P_WO_01

@raa
@raaprovider
@regression
Scenario: RAA_P_WO_01 - Provider verifies ‘National Minimum Wage' option 
        When Provider selects 'National Minimum Wage' in the first part of the journey
        Then the Provider verify 'National Minimum Wage' the wage option selected in the Preview page