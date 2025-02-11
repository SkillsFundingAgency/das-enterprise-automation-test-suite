Feature: TM_08_MultipleApplicationForSamePledge

@regression
@transfermatching
Scenario: TM_08_Multiple Application For Same Pledge
	Given the levy employer logins using existing transfer matching account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	When the receiver levy employer applies for the pledge
	When the non levy employer applies for the pledge