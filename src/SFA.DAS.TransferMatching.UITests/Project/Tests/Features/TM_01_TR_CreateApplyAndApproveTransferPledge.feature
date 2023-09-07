Feature: TM_01_TR_CreateApplyAndApproveTransferPledge

@regression
@transfermatching
Scenario: TM_01_TR_Create Apply and Approve transfer pledge
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the transfer receiver applies for the pledge
	Then the levy employer can approve the application and verify costing model