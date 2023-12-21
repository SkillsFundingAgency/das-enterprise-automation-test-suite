Feature: AAN_A_07_VerifyApprenticeProfileAndSendMessage


@aan
@aanaprentice
@regression
Scenario: AAN_A_07_VerifyApprenticeProfileAndSendMessage
    Given an onboarded apprentice logs into the AAN portal
    Then the user should be able to successfully verify an apprentice member profile
    And the user should be able to ask for industry advice to an apprentice member successfully
    And the user should be able to ask for help with a network activity to an apprentice member successfully
    And the user should be able to request a case study to an apprentice member successfully
    And the user should be able to get in touch after meeting at a network event to an apprentice member successfully
