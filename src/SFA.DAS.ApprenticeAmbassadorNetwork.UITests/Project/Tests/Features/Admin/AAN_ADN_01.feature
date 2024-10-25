Feature:AAN_ADN_01

@aan
@aanadmin
@aanadn01
@regression
Scenario: AAN_ADN_01 admin user filter events
    Given an admin logs into the AAN portal
    Then the user should be able to successfully filter events by date
    And the user should be able to successfully filter events by event status
    And the user should be able to successfully filter events by event type
    And the user should be able to successfully filter events by regions
    And the user should be able to successfully filter events by multiple combination of filters
    
@aan
@aanadmin
@aanadn01b
@regression
Scenario: AAN_ADN_01b admin user filter events
    Given an admin logs into the AAN portal
    And an event called 'Location Filter Test Event 1' in 'Bromsgrove' has been created
    #And an event called 'Location Filter Test Event 2' in 'Kidderminster' has been created
    #And an event called 'Location Filter Test Event 3' in 'Sunderland' has been created
    #When an admin logs into the AAN portal
    #And the user filters events within '10' miles of 'Bromsgrove'
    #Then event search results should include 'Location Filter Test Event 1'
    #And the event search results should include 'Location Filter Test Event 2'
    #And the event search results should not include 'Location Filter Test Event 3'
