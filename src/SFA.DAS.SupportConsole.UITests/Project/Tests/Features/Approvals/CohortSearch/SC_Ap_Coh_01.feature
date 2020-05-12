Feature: SC_Ap_Coh_01

@regression
@supportconsole
@approvalssupportconsole
Scenario: SC_Ap_Coh_01 - View Cohort details
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the User searches for a Cohort
	And the User clicks on 'View this cohort' button
	And the user chooses to view Uln of the Cohort 
	Then the ULN details page is displayed