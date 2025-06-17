Feature: AAN_A_06_VerifyAndUpdateAmbassadorProfile


@aan
@aanaprentice
@regression
Scenario: AAN_A_06_VerifyAndUpdateAmbassadorProfile
    Given an onboarded apprentice logs into the AAN portal
    When the user should be able to successfully verify ambassador profile
    Then the user should be able to update profile information
