Feature: TM_15_NLCanAutoApprove

@regression
@transfermatching
Scenario: TM_15_NL Can auto approve application when shown options
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer can auto approve the application
	And the non levy employer can accept funding
	Then the non levy employer can add apprentice to the pledgeApplication
	Then the provider updates with Ulns and approves the cohorts
	And the non levy employer logins using existing transfer matching account
	Then Verify a new live apprenticeship record is created