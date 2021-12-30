Feature: TM_12_SenderRejectApplication
	
@regression
@transfermatching
Scenario: TM_12_Sender can reject application
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can reject the application
	