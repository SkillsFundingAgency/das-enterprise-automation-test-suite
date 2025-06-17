Feature: TM_16_SenderDownloadExcel

@regression
@transfermatching
Scenario: TM_16_Sender can download the excel file of applications
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer can download excel file