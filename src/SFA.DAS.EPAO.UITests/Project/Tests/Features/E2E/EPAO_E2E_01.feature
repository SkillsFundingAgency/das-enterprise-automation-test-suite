Feature: EPAO_E2E_01
#disabling this test because the apply journey is disabled but there is a new journey that will come after august.
@epaoapply
@e2e
Scenario: EPAO_E2E_01 - Apply Approve and Add a standard
Given the apply user submits an Assessment Service Application
	And the admin appoves the assessor
	When the apply user applies for a standard 
    Then the admin approves the standard 
    And make the epao live