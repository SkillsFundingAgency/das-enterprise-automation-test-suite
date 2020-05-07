Feature: SC_Ma_Challenge_01


@regression
@supportconsole
@masupportconsole
Scenario: SC_Ma_Challenge_01 Challenge response page
	Given the Tier 1 User is logged into Support Console
	And the User is on the Account details page
	When the user navigates to finance page
	Then the user is redirected to a challenge page
