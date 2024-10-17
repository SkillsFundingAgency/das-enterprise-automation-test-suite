Feature: TM_28_NoImmediateAutoApprovalWhenNotCompleteMatch

@regression
@transfermatching
Scenario: TM_28_AutoApproval Does Not Occur When Not a Complete Match
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using non default criteria and immediate approval
	And the levy employer can view pledges from verification page

	#one of these two is to be used
		#When the non levy employer applies for the pledge but is not 100% match
			Then the non levy employer can apply for the pledge but is not immediately autoapproved


	And the levy employer can view the awaiting your approval application

	# these are new
	Then It is 7 days before an application reaches 3 months without any action
    And the levy employer will be able to view auto rejected date of application under status tag 'Application expires on dd/mm/yy'