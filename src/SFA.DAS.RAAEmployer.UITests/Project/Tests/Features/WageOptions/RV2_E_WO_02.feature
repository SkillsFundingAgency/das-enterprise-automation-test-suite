Feature: RAA_E_WO_02

@raa
@raaemployer
@regression
Scenario: RAA_E_WO_02 - Employer verifies ‘National Minimum Wage For Apprentices' option 
        When Employer selects 'National Minimum Wage For Apprentices' in the first part of the journey
        Then the Employer verify 'National Minimum Wage For Apprentices' the wage option selected in the Preview page