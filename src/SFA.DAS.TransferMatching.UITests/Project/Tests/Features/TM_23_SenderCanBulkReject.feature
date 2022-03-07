Feature: TM_23_SenderCanBulkReject

@regression
@transfermatching
Scenario: TM_23_Sender can bulk reject application made by receiver
Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer cancels bulk reject application
	And the levy employer can bulk reject application 
