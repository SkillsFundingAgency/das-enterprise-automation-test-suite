Feature: TM_29_CreateDelayedTransferPledgeApprovedAfter6Weeks

@regression
@transfermatching
Scenario:TM_29_Create Delayed Transfer Pledge and Approve After 6 Weeks
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then wait for 6 weeks
	And the non levy employer can open approved pledge application