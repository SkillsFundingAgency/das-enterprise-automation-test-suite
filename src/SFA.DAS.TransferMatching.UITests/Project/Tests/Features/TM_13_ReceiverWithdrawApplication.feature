Feature: TM_13_ReceiverWithdrawApplication

@regression
@transfermatching
Scenario: TM_13_Receiver Can Withdraw Applicatio
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria 
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can approve the application
	And the non levy employer can withdraw funding