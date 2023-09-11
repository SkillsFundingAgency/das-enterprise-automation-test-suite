Feature: AAN_E_02_Events


@aan
@aanemployerevents
@aanemployer
@regression
Scenario: AAN_E_02_A Employer signup and cancel the attendance for an event
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully signup for a future event
    And the user should be able to successfully Cancel the attendance for a signed up event

@aan
@aanemployerevents
@aanemployer
@regression
Scenario: AAN_E_02_B Employer filter events
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event format
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
