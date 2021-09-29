Feature: TM_03_CreateTransferPledgeTransactorUser

@regression
@transfermatching
Scenario: TM_03_Create Transfer pledge using Transactor User
	Given the Employer logins using existing transactor user account
	Then the Employer can create pledge using default criteria
	And the Employer can view pledges from verification page