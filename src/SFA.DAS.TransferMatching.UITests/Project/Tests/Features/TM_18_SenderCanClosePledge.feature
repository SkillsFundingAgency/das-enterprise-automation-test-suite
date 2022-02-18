Feature: TM_18_SenderCanClosePledge

@regression
@transfermatching
Scenario: TM_18_Sender can create a pledge and close it
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	Then the levy employer can close the pledge 
