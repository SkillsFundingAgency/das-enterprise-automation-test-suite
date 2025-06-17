Feature: AAN_E_02_SignUpEvents


@aan
@aanemployerevents
@aanemployer
@regression
Scenario: AAN_E_02_Employer signup and cancel the attendance for an event
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully signup for a future event
    And the user should be able to successfully Cancel the attendance for a signed up event
