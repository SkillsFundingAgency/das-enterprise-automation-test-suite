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
    And the user should be able to successfully filter events by multiple combination of filters


@aan
@aanemployerevents
@aanemployer
@aanemployer03b
@regression
Scenario: AAN_A_03b_Employer user filters events by location
    Given the following events have been created:
    | Event Title                             | Location                                                                    |
    | Location Filter Employer Test Event 1 | The Maids Head, King's Lynn, PE32 1NG                                       |
    | Location Filter Employer Test Event 2 | Eagles Golf Club, 37-39 School Road, King's Lynn, PE34 4RS                  |
    | Location Filter Employer Test Event 3 | Spalding United Football Club, Sir Halley Stewart Field, Spalding, PE11 1DA |
    When an onboarded employer logs into the AAN portal
    And the user filters events within 10 miles of "PE30 5HF"
    Then the following events can be found within the search results:
    | Event Title                             |
    | Location Filter Employer Test Event 1 |
    | Location Filter Employer Test Event 2 |
    And the following events can not be found within the search results:
    | Event Title                             |
    | Location Filter Employer Test Event 3 |
    When the user filters events Across England centered on "PE30 5HF"
    And the user orders the results by Closest
    Then the following events can be found within the search results in the given order:
    | Event Title                             | Order |
    | Location Filter Employer Test Event 1 | 1     |
    | Location Filter Employer Test Event 2 | 2     |
    | Location Filter Employer Test Event 3 | 3     |

@aan
@aanemployerevents
@aanemployer
@aanemployer03b
@regression
Scenario:AAN_A_03c Employer user filters events by a location that does not exist
    Given an onboarded employer logs into the AAN portal
    When the user filters events within 10 miles of "Lilliput"
    Then the heading text "We cannot find the location you entered" is displayed
    And the text "We do not recognise Lilliput" is displayed

@aan
@aanemployerevents
@aanemployer
@aanemployer03b
@regression
Scenario:AAN_A_03d Employer user filters events and finds no matching results
    Given an onboarded employer logs into the AAN portal
    When the user navigates to Network Events
    And the user filters events so that there are no results
    Then the heading text "No events currently match your filters" is displayed
