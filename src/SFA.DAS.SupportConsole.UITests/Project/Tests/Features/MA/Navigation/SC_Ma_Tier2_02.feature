Feature: SC_Ma_Tier2_02


@regression
@supportconsole
@masupportconsole
Scenario: SC_Ma_Tier2_02_Tier2Navigation To Team Members page
	Given the Tier 2 User is logged into Support Console
	And the User is on the Account details page
	When the user navigates to team members page
	Then the user can view employer user information
