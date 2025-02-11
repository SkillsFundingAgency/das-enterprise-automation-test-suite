Feature: TM_26_SenderCanFilterPledges

@regression
@transfermatching
Scenario: TM_26_Sender can filter pledges by business sector on opportunity page
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can filter pledges 
