Feature: SC_ApULN_02

@regression
@supportconsole
@approvalssupportconsole
Scenario: SC_ApULN_02 - Invalid ULN search
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the User searches with a invalid ULN
	Then appropriate ULN error message is shown to the user
	When the User searches with a invalid ULN having special characters
	Then appropriate ULN error message is shown to the user