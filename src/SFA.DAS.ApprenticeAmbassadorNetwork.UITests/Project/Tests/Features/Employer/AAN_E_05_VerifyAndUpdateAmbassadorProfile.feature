Feature: AAN_E_05_VerifyAndUpdateAmbassadorProfile


@aan
@aanemployer
@regression
Scenario: AAN_E_05_VerifyAndUpdateAmbassadorProfile
    Given an onboarded employer logs into the AAN portal
    When the user should be able to successfully verify ambassador profile
    Then the user should be able to update profile information
