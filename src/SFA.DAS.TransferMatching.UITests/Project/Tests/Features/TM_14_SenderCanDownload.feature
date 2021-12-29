Feature: TM_14_SenderCanDownload
	Simple calculator for adding two numbers

@regression
@transfermatching
Scenario: TM_14_Sender can see download link
	Given the levy employer logins using existing transfer matching acccount
	And the levy employer can create pledge using default criteria
	When the levy employer can view pledges from the verification page
	And the reciever levy employer applies for the pledge
	Then the levy employer can see the download link