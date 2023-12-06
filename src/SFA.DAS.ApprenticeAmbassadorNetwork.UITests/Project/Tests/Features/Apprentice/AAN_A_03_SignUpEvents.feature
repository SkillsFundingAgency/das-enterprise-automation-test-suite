Feature: AAN_A_03_SignUpEvents


@aan
@aanaprenticeevents
@aanaprentice
@regression
@accessibility
Scenario: AAN_A_03_Apprentice signup and cancel the attendance for an event
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully signup for a future event
    And the user should be able to successfully Cancel the attendance for a signed up event
