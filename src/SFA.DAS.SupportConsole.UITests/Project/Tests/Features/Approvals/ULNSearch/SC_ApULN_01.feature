Feature: SC_ApULN_01

@regression
@supportconsole
@approvalssupportconsole
Scenario: SC_ApULN_01 - View ULN details
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the User searches for an ULN
	Then the ULN details are displayed