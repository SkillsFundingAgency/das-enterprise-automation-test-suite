Feature: AAN_A_03_Events


@aan
@aanevents
@aanaprentice
@regression
Scenario: AAN_A_03_A User should be able to successfully signup and cancel the attendance for an event
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfuly signup for a future event
    And the user should be able to successfuly Cancel the attendance for a signed up event

@aan
@aanevents
@aanaprentice
@regression
Scenario: AAN_A_03_B User should be able to successfully Filter Events
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfuly filter events by date
    And the user should be able to successfuly filter events by event format
    And the user should be able to successfuly filter events by event type
    And the user should be able to successfuly filter events by multiple combination of filters
