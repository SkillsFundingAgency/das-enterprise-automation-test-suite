Feature: RV2_E_WO_04


@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_WO_01 - Employer verifies ‘Fixed Wage Type' option also know as set wage yourself
	When Employer selects 'Fixed Wage Type' in the first part of the journey
    Then the Employer verify 'Fixed Wage Type' the wage option selected in the Preview page

