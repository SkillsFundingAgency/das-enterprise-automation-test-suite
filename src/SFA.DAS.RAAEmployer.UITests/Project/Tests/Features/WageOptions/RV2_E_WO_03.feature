Feature: RV2_E_WO_03

A short summary of the feature

@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_WO_03 - Employer verifies ‘Set as Competitive' option
	When Employer selects 'Set As Competitive' in the first part of the journey
    Then the Employer verify 'Set As Competitive' the wage option selected in the Preview page

