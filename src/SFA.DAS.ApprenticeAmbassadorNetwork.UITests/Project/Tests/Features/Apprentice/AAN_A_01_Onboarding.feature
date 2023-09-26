Feature: AAAN_A_01_Onboarding

@aan
@aanonboarding
@aanaprentice
@aanapprenticeonboardingreset
@regression
Scenario: AAN_A_01A User successfully completes the Apprentice onboarding process and verifies the Hub page
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page

@aan
@aanonboarding
@aanaprentice
@aanapprenticeonboardingreset
@regression
Scenario:AAN_A_01B User without manager permission encounters a shutter page
    Given an apprentice logs into the AAN portal
    When the user does not have manager permission
    Then a shutter page should be displayed

@aan
@aanonboarding
@aanaprentice
@aanapprenticeonboardingreset
@regression
Scenario:AAN_A_01C User completes all onboarding details and can modify answers on the "Check Your Answer" page
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    And the user should be able to modify any of the provided answers
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page

@aan
@aanonboarding
@aanaprentice
@aanapprenticeonboardingreset
@regression
Scenario:AAN_A_01D User completes onboarding process and lands on the AAN Hub page after signing in
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    Then the user can sign back in to the AAN Apprentice platform
