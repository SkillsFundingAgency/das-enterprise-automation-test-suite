Feature: TM_02_CreateAnonymousPledgeApplyAndApprove

@regression
@transfermatching
Scenario: TM_02_Create Anonymous pledge using non default criteria Apply and Approve
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create anonymous pledge using non default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer can approve the application