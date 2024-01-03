Feature: AAN_A_08_VerifyRegionalChairProfileAndSendMessage


@aan
@aanaprentice
@regression
Scenario: AAN_A_08_VerifyRegionalChairProfileAndSendMessage
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully verify a regional chair member profile
    And the user should be able to ask for industry advice to a regional chair member successfully
    And the user should be able to ask for help with a network activity to a regional chair member successfully
    And the user should be able to request a case study to a regional chair member successfully
    And the user should be able to get in touch after meeting at a network event to a regional chair member successfully
