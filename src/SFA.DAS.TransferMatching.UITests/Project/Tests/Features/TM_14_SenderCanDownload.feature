Feature: TM_14_SenderCanDownload
	Simple calculator for adding two numbers

@regression
@transfermatching
Scenario: TM_14_Sender can see download link
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can see the download link