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

@aan
@aanaprenticeevents
@aanaprentice
@regression
Scenario: AAN_A_04b_Apprentice user filters events by location
    Given the following events have been created:
    | Event Title                  | Location                          |
    | Location Filter Test Event 1 | 1 Paradise, Scarborough, YO11 1RB |
    | Location Filter Test Event 2 | 5 East Terrace, Whitby, YO21 3HB  |
    | Location Filter Test Event 3 | 23 Shambles, York, YO1 7LZ        |
    When an onboarded apprentice logs into the AAN portal
    And the user filters events within 20 miles of "YO11 1QB"
    Then the following events can be found within the search results:
    | Event Title                  |
    | Location Filter Test Event 1 |
    | Location Filter Test Event 2 |
    And the following events can not be found within the search results:
    | Event Title                  |
    | Location Filter Test Event 3 |