Feature: SC_Ap_ULN_01

@awaiting-fix
@supportconsole
@approvalssupportconsole
Scenario: SC_Ap_ULN_01 - View ULN details
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the User searches for an ULN
	Then the ULN details are displayed