Feature: TM_28_NoImmediateAutoApprovalWhenNotCompleteMatch

@regression
@transfermatching
Scenario: TM_28_AutoApproval Does Not Occur When Not a Complete Match
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using non default criteria and immediate approval
	And the levy employer can view pledges from verification page
	Then the non levy employer can apply for the pledge but is not immediately autoapproved
