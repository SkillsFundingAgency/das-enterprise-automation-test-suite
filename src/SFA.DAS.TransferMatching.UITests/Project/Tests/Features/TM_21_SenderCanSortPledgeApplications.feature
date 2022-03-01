Feature: TM_21_SenderCanSortPledgeApplications

@regression
@transfermatching
Scenario: TM_21_Sender can sort the pledges by the different fields
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	Then the levy employer can sort the pledges
