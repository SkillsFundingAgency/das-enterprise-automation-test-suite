Feature: AAN_E_03_FilterEvents

@aan
@aanemployerevents
@aanemployer
@regression
Scenario: AAN_E_03_Employer filter events
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event format
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
