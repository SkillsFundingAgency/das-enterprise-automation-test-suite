Feature: AP_EAN_01

@regression
@approvals
Scenario: AP_EAN_01_Verify Existing Transactor user can add an apprentice
	Given the Employer logins using existing transactor user account
	Then the user can add an apprentices
