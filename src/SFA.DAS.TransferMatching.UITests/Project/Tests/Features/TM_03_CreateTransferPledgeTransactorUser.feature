Feature: TM_03_CreateTransferPledgeTransactorUser

@regression
@transfermatching
Scenario: TM_03_Create Transfer pledge using Transactor User
	Given the levy employer login using existing transactor user account
	Then the levy employer can create pledge using default criteria
	And the levy employer can view pledges from verification page
	And the pledge is available to apply