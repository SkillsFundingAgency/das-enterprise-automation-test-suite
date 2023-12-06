Feature:AAN_ADN_01

@aan
@aanadmin
@aanadn01
@regression
@accessibility
Scenario: AAN_ADN_01 admin user filter events
    Given an admin logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event status
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
