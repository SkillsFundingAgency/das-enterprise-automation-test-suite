Feature: SC_Accessibility


@regression
@supportconsole
@masupportconsole
Scenario: SC_ACC_01_Tier2Navigation
	Given the Tier 2 User is logged into Support Console
	And the User is on the Account details page
	When the user navigates to finance page
	Then the user is redirected to finance page
	And the user can view levy declarations
	When the user navigates to finance page
	Then the user is redirected to finance page
	And the user can view transactions
	When the user navigates to team members page
	Then the user can view employer user information
