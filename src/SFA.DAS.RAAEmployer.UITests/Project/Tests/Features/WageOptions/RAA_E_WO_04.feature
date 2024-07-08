Feature: RAA_E_WO_04


@raa
@raaemployer
@regression
Scenario: RAA_E_WO_04 - Employer verifies ‘Fixed Wage Type' option also know as set wage yourself
	When Employer selects 'Fixed Wage Type' in the first part of the journey
    Then the Employer verify 'Fixed Wage Type' the wage option selected in the Preview page

