Feature: TM_13_SenderSelectAutoOption

@regression
@transfermatching
Scenario: TM13_Sender can select the auto option
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can auto approve the application