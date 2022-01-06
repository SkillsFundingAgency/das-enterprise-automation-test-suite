Feature: TM14_SenderCanDownload

@regression
@transfermatching
Scenario: TM14_Sender can select download
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can see the download link