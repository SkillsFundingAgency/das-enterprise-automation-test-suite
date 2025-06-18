Feature: AAN_A_09_HideAndDisplayAmbassadorProfile


@aan
@aanaprentice
@regression
Scenario: AAN_A_09_HideAndDisplayAmbassadorProfile
    Given an onboarded apprentice logs into the AAN portal
    When the user should be able to successfully hide ambassador profile information
    Then the user should be able to successfully display ambassador profile information
