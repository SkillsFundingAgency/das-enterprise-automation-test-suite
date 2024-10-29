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
    | Event Title                  | Location                                                                    |
    | Location Filter Test Event 1 | The Maids Head, King's Lynn, PE32 1NG                                       |
    | Location Filter Test Event 2 | Eagles Golf Club, 37-39 School Road, King's Lynn, PE34 4RS                  |
    | Location Filter Test Event 3 | Spalding United Football Club, Sir Halley Stewart Field, Spalding, PE11 1DA |
    When an onboarded apprentice logs into the AAN portal
    When the user filters events within 10 miles of "PE30 5HF"
    Then the following events can be found within the search results:
    | Event Title                  |
    | Location Filter Test Event 1 |
    | Location Filter Test Event 2 |
    And the following events can not be found within the search results:
    | Event Title                  |
    | Location Filter Test Event 3 |