Feature: TM_10_TransferUsersNoFunds

@regression
@transfermatching
Scenario: TM_10_Display the ‘Apply for transfers funding’ section to levy-paying employers that are not currently sending transfer funds
	Given the levy employer who are not currently sending transfer funds login
	Then the levy employer can apply for transfer opportunities