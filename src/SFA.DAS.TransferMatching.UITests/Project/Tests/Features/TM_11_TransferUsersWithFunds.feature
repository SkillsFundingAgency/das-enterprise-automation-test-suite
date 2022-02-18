Feature: TM_11_TransferUsersWithFunds

@regression
@transfermatching
Scenario: TM_11_Do not display the ‘Apply for transfers funding’ section to levy-paying employers that are currently sending transfer funds
	Given the levy employer who are currently sending transfer funds login
	Then the levy employer is able to apply for transfer opportunities
	And the levy employer currently receiving funds can create pledge
