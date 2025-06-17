Feature: TM_33_AutoClosethePledgeWhenBalanceDropsBelow2000

@regression
@transfermatching
Scenario: TM_33_AutoClose the Pledge When Balance Drops Below 2000	 
    Given the levy employer logins using existing transfer matching account
    Then the levy employer can create pledge with funding equal to course cost
    When the levy employer is viewing pledges from verification page
    When the non levy employer applies for the pledge
    Then the levy employer can approve the application         
    Then the Pledge balance drops below £2,000 Pledge should be auto closed
    Then the levy employer confirms the pledge displays as closed
    Then Pledge wont be shown publicly  