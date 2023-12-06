Feature: AAN_A_05_FilterAllEventsNetworkDirectory

@aan
@aanaprenticeevents
@aanaprentice
@regression
@accessibility
Scenario: AAN_A_05_Apprentice filter all events Network Directory
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully filter events by role Network Directory
    And the user should be able to successfully filter events by regions Network Directory
    And the user should be able to successfully filter events by multiple combination of filters Network Directory
