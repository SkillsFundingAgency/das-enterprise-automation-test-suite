Feature: AAN_01_OnboardingJourney

@aan
@aan01
@aanreset
@regression
Scenario: AAN01A User successfully completes the Apprentice onboarding process and verifies the Hub page
	Given the provider logs into AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page


@aan
@aan02
@aanreset
@regression
Scenario:AAN01B User without manager permission encounters a shutter page
    Given the provider logs into AAN portal
    When the user does not have manager permission
    Then a shutter page should be displayed

@aan
@aan03
@aanreset
@regression
Scenario:AAN01C User completes all onboarding details and can modify answers on the "Check Your Answer" page
	Given the provider logs into AAN portal
	When the user provides all the required details for the onboarding journey
    And the user should be able to modify any of the provided answers
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page

@aan
@aan04
@aanreset
@regression
Scenario:AAN01D User completes onboarding process and lands on the AAN Hub page after signing in
    Given the provider logs into AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    When the user signs back in to the AAN platform
    Then the user should be redirected to the AAN Hub page