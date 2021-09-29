Feature: TM_02_CreateAnonymousPledge

@regression
@transfermatching
Scenario: TM_02_Create Anonymous pledge using non default criteria and view
	Given the Employer logins using existing Transfer Matching Account
	Then the Employer can create anonymous pledge using non default criteria
	And the Employer can view pledges from verification page