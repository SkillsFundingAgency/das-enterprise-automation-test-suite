@accessibility
@transfermatching
Feature: TM_Accessibility

Scenario: TM_ACC_01 Create Apply Approve and Accept transfer pledge - Add apprentice
	Given the levy employer logins using existing transfer matching account
	And the levy employer can create pledge using default criteria
	When the levy employer is viewing pledges from verification page
	And the non levy employer applies for the pledge
	Then the levy employer can approve the application
	And the non levy employer can accept funding
	And the non levy employer can add apprentice to the pledgeApplication