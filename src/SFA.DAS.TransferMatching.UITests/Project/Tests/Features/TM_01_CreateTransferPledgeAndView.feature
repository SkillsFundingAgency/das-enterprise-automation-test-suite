Feature: TM_01_CreateTransferPledgeAndView

@regression
@transfermatching
Scenario: TM_01_Create transfer pledge with default criteria and view
	Given the Employer logins using existing Transfer Matching Account
	Then the Employer can create pledge using default criteria
	And the Employer can view pledges