Feature: AAN_E_01_Onboarding

@aan
@aanemployer
@aanemployeronboardingreset
@regression
Scenario: AAN_E_01A User successfully completes the Employer onboarding process and verifies the Hub page
    Given an employer without onboarding logs into the AAN portal
	When the employer provides all the required details for the employer onboarding journey
    Then the employer onboarding process should be successfully completed
    And the employer should be redirected to the employer Hub page


@aan
@aanemployer
@aanemployeronboardingreset
@regression
Scenario:AAN_E_01B User completes all onboarding details and can modify answers on the "Check Your Answer" page
    Given an employer without onboarding logs into the AAN portal
    When the employer should be able to modify any of the provided answers
   Then the employer onboarding process should be successfully completed
    And the employer should be redirected to the employer Hub page

