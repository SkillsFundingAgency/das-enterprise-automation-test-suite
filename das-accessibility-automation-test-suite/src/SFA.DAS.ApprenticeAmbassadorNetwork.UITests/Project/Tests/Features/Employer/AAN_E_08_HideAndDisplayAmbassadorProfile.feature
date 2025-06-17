Feature: AAN_E_08_HideAndDisplayAmbassadorProfile


@aan
@aanemployer
@regression
Scenario: AAN_A_08_HideAndDisplayAmbassadorProfile
    Given an onboarded employer logs into the AAN portal
    When the user should be able to successfully hide ambassador profile information
    Then the user should be able to successfully display ambassador profile information
