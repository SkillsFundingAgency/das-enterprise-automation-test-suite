Feature: TM_19_SenderDoesntClosePledge
	
@regression
@transfermatching
Scenario: TM_19_Sender can create a pledge and doesnt close it
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	Then the levy employer doesn't close the pledge
