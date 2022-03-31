Feature: TM_27_SenderCanViewPledgedAmount

@regression
@transfermatching
Scenario: TM_27_Sender can view the pledged amount and the remaining amount
	Given the levy employer logins using existing transfer matching account
    Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
    Then the levy employer can view pleged amount