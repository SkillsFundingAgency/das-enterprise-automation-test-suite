Feature: AAN_E_04_FilterEventsNetworkDirectory

@aan
@aanemployerevents
@aanemployer
@regression
Scenario: AAN_E_04_Employer filter events Network Directory
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully filter events by role Network Directory
    And the user should be able to successfully filter events by regions Network Directory
    And the user should be able to successfully filter events by multiple combination of filters Network Directory
