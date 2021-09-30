Feature: TM_01_NL_CreateApplyAndApproveTransferPledge

@regression
@transfermatching
@validatepledgeamount
Scenario: TM_01_NL_Create Apply and Approve transfer pledge
	Given the Employer logins using existing Transfer Matching Account
	Then the Employer can create pledge using default criteria
	And the Employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the Employer can approve the application