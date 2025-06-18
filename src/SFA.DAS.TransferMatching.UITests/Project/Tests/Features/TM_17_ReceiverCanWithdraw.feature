Feature: TM_17_ReceiverCanWithdraw

@regression
@transfermatching
Scenario: TM_17_Receiver can apply for funding and withdraw
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer can approve the application
	And the non levy employer can withdraw funding