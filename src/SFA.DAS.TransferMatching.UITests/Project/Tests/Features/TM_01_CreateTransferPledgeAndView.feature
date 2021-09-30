Feature: TM_01_CreateApplyAndApproveTransferPledge

@regression
@transfermatching
@validatepledgeamount
Scenario: TM_01_Create Apply and Approve transfer pledge
	Given the Employer logins using existing Transfer Matching Account
	Then the Employer can create pledge using default criteria
	And the Employer can view pledges from verification page
	When the receiver applies for the pledge
	Then the Employer can approve the application