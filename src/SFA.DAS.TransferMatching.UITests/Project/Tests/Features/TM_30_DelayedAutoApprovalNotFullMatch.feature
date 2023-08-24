Feature: TM_30_DelayedAutoApprovalNotFullMatch

@regression
@transfermatching
Scenario:TM_30_DelayedAutoApproval with non-100% match is not autoapproved
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create anonymous pledge using non default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then wait for 6 weeks
	And the non levy employer can open awaiting approval pledge application
