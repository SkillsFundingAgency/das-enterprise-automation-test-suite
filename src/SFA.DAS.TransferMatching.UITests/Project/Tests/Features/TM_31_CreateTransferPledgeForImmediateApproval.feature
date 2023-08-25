Feature: TM_31_CreateTransferPledgeForImmediateApproval

@regression
@transfermatching
Scenario: TM_31_Create Transfer Pledge For Immediate Approval
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge for immediate approval using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
