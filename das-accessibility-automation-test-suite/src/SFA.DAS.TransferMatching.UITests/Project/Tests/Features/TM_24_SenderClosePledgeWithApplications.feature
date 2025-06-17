Feature: TM_24_SenderClosePledgeWithApplications
	
@regression
@transfermatching
Scenario: TM_24_Sender can close a pledge that has applications
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	Then the non levy employer can apply for the pledge
	And the levy employer can close the pledge