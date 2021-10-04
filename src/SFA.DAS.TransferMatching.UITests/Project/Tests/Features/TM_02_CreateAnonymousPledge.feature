Feature: TM_02_CreateAnonymousPledge

@regression
@transfermatching
Scenario: TM_02_Create Anonymous pledge using non default criteria and view
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create anonymous pledge using non default criteria
	And the levy employer can view pledges from verification page