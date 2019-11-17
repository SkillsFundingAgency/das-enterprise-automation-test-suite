Feature: SC_ApCoh_01

@regression
@supportconsole
@approvalssupportconsole
Scenario: SC_ApCoh_01 - View Cohort details
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the User searches for a Cohort
	Then the Cohort Summary page is displayed
	When the User clicks on 'View this cohort' button
	Then the Cohort Details page is displayed
	When the user chooses to view Uln of the Cohort 
	Then the ULN details page is displayed