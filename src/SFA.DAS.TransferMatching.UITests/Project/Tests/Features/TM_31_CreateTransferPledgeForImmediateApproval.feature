Feature: TM_31_CreateTransferPledgeForImmediateApproval

@regression
@transfermatching
Scenario: TM_31_Create Transfer Pledge For Immediate Approval And Auto Decline Approved Application When Not Actioned By Receiving Employer In 6 Weeks
		Given the levy employer logins using existing transfer matching account
		Then the levy employer can create pledge for immediate approval using default criteria
		And the levy employer can view pledges from verification page
		When the receiver levy employer applies for the pledge
		Then the levy employer can view the approved application

		##new 
		When 6 weeks have passed since the application was approved
		
		Then the approved application should auto declined
        And the deducted funds should be automatically refunded to the sending employer's account. 