Feature: TM_01_TR_CreateApplyAndApproveTransferPledge

@regression
@transfermatching
Scenario: TM_01_TR_Create Apply and Approve transfer pledge funds accepted by receiving employer but unused will exoire in 3 months.
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the transfer receiver applies for the pledge
	Then the levy employer can approve the application and verify costing model
	Then the receiver employer can accept funding
	When 3 months have passed since the funds accepted
    Then the accepted funds should expire
    And the expired funds should be automatically refunded to the sending employer's account