Feature: TM_01_ViewTransfers

@regression
@transfermatching
Scenario: TM_01_ViewTransfer Pledges
	Given the Employer logins using existing Transfer Matching Account
	Then the Employer can create pledge using default criteria
	And the Employer can view transfers 