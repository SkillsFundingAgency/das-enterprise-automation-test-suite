Feature: AAN_A_03_Events


@aan
@aanevents
@aanaprentice
@regression
Scenario: AAN_A_03_A Apprentice signup and cancel the attendance for an event
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully signup for a future event
    And the user should be able to successfully Cancel the attendance for a signed up event

@aan
@aanevents
@aanaprentice
@regression
Scenario: AAN_A_03_B Apprentice filter events
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event format
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
