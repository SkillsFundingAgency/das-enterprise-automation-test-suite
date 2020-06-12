Feature: EPAO_E2E_01

@epao
@epaoapply
@regression
Scenario: EPAO_E2E_01 - Apply Approve and Add a standard
Given the apply user submits an Assessment Service Application
	And the admin appoves the assessor
	When the apply user applies for a standard 
    Then the admin approves the standard 
    And make the epao live