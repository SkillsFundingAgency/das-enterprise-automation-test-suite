Feature: TM15_NLCanAutoApprove
	Simple calculator for adding two numbers

@regression
@transfermatching
Scenario: TM_15_NL Can auto approve
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the non levy employer applies for the pledge
	Then the levy employer can auto approve the application