Feature: RAA_P_WO_04

@raa
@raaprovider
@regression
Scenario: RAA_P_WO_04 - Provider verifies ‘Set as Competitive' option 
        When Provider selects 'Set As Competitive' in the first part of the journey
        Then the Provider verify 'Set As Competitive' the wage option selected in the Preview page
