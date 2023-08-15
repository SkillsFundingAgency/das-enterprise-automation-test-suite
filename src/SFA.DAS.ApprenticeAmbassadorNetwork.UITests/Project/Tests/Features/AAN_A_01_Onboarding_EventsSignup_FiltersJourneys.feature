Feature: AAAN_A_01_Onboarding_EventsSignup_FiltersJourneys

@aan
@aanonboarding
@aan01
@aanreset
@regression
Scenario: AAN_A_01A User successfully completes the Apprentice onboarding process and verifies the Hub page
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page

@aan
@aanonboarding
@aan02
@aanreset
@regression
Scenario:AAN_A_01B User without manager permission encounters a shutter page
    Given an apprentice logs into the AAN portal
    When the user does not have manager permission
    Then a shutter page should be displayed

@aan
@aanonboarding
@aan03
@aanreset
@regression
Scenario:AAN01C User completes all onboarding details and can modify answers on the "Check Your Answer" page
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    And the user should be able to modify any of the provided answers
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page

@aan
@aanonboarding
@aan04
@aanreset
@regression
Scenario:AAN01D User completes onboarding process and lands on the AAN Hub page after signing in
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    Then the user can sign back in to the AAN platform

@ignore
@aan
@aanevents
@aan06
@aanreset
@regression
Scenario: AAN01E User should be able to successfully signup and cancel the attendacne for an event
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly signup for a future event
    And the user should be able to successfuly Cancel the attendance for a signed up event

@aan
@aaneventsfilters
@aan07
@aanreset
@regression
Scenario: AAN01F User should be able to successfully Filter Events by date 
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly filter events by date


@aan
@aaneventsfilters
@aan08
@aanreset
@regression
Scenario: AAN01G User should be able to successfully Filter Events by Type 
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly filter events by event format


@aan
@aaneventsfilters
@aan09
@aanreset
@regression
Scenario: AAN01H User should be able to successfully Filter Events by Event type 
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly filter events by event type

   
@aan
@aaneventsfilters
@aan10
@aanreset
@regression
Scenario: AAN01I User should be able to successfully Filter Events by multiple combination of filters
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly filter events by multiple combination of filters
