Feature: TM_01_NL_CreateApplyApproveAndAcceptTransferPledge_AddApprentice

@regression
@transfermatching
Scenario: TM_01_NL_Create Apply Approve and Accept transfer pledge - Add apprentice
	Given the levy employer logins using existing transfer matching account
	And the levy employer can create pledge using default criteria
	When the levy employer is viewing pledges from verification page
	And the non levy employer applies for the pledge
	Then the levy employer can approve the application
	And the non levy employer can accept funding
	And the non levy employer can add apprentice to the pledgeApplication