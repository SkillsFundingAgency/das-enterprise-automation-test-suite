Feature: TM_16_SenderCanSeeTheDownloadLink
	
@regression
@transfermatching
Scenario: TM_16_Sender can see download link on pledges page
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	Then the levy employer can see the download link