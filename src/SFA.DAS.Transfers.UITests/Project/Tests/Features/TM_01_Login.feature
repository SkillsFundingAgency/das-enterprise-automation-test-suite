Feature: TM_01_Login
	User Login with multiple roles

@levy_transfers
Scenario: Log in as a Levy User and select Owner Account
	Given Levy User with multiple accounts logs in
	And they select an Owner Account
	Then they are presented with a Your Transfers Finance section

Scenario: Log in as a Levy User and select Transactor Account
	Given Levy User with multiple accounts logs in
	And they select an Transactor Account
	Then they are presented with a Your Transfers Finance section

Scenario: Log in as a Levy User and select Viewer Account
	Given Levy User with multiple accounts logs in
	And they select an Viewer Account
	Then they are presented with a Your Transfers Finance section

Scenario: Log in as a non-Levy User 
	Given Levy User with multiple accounts logs in
	And they select an Viewer Account
	Then they are presented with a Your Transfers Finance section
