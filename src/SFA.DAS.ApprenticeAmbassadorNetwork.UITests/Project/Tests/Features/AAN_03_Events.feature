Feature: AAN_03_Events_Filters

@ignore
@aan
@aanaprentice
@aan07
@regression
Scenario: AAN03_1A User should be able to successfully Filter Events by date 
    Given an apprentice logs into the AAN portal
	When the user provides all the required details for the onboarding journey
    Then the Apprentice onboarding process should be successfully completed
    And the user should be redirected to the Hub page
    And the user should be able to successfuly filter events by date
