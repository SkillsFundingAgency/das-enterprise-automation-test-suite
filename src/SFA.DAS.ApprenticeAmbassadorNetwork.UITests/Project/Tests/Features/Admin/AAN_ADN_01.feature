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
    And the following events have been created:
    | EventTitle                   | Location                                                                    |
    | Location Filter Test Event 1 | The Maids Head, King's Lynn, PE32 1NG                                       |
    | Location Filter Test Event 2 | Eagles Golf Club, 37-39 School Road, King's Lynn, PE34 4RS                  |
    | Location Filter Test Event 3 | Spalding United Football Club, Sir Halley Stewart Field, Spalding, PE11 1DA |
    When the user filters events within 10 miles of "PE30 5HF"
    Then the event search results should include 'Location Filter Test Event 1'
    And the event search results should include 'Location Filter Test Event 2'
    And the event search results should not include 'Location Filter Test Event 3'
