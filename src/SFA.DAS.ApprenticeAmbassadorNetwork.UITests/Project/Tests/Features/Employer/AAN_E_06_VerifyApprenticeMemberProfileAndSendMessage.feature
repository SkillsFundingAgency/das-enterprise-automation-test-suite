Feature: AAN_E_06_VerifyApprenticeMemberProfileAndSendMessage


@aan
@aanemployer
@regression
Scenario: AAN_E_06_VerifyApprenticeMemberProfileAndSendMessage
    Given an onboarded employer logs into the AAN portal
    Then the user should be able to successfully verify apprentice member profile
    And the user should be able to ask for industry advice to the member successfully
    And the user should be able to ask for help with a network activity to the member successfully
    And the user should be able to request a case study to the member successfully
    And the user should be able to get in touch after meeting at a network event to the member successfully
