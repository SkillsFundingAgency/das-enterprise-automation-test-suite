Feature: TM_20_ReceiverCanWithdrawBeforeApproval

@regression
@transfermatching
Scenario: TM_20_Receiver can withdraw funding before sender has approved
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the non levy employer can withdraw funding before approval
