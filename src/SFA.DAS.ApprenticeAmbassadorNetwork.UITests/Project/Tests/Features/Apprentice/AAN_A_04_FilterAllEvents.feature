Feature: AAN_A_04_FilterAllEvents

@aan
@aanaprenticeevents
@aanaprentice
@regression
Scenario: AAN_A_04_Apprentice filter all events
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event format
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
