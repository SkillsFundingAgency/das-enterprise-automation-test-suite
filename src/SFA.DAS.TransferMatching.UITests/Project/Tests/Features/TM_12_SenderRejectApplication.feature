Feature: TM_12_SenderRejectApplication
	
@regression
@transfermatching
Scenario: TM_12_Sender can reject application
	Given the levy employer logins using existing transfer matching acccount
	And the levy employer can create pledge using default criteria
	When the levy employer can view pledges from the verification page
	And the reciever levy employer applies for the pledge
	Then the levy employer can reject the application
	