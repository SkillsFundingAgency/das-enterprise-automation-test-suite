Feature: SC_Ap_Coh_04

@supportconsole
@approvalssupportconsole
Scenario: SC_Ap_Coh_04 - View Cohort details with pending changes
	Given the Tier 1 User is logged into Support Console
	And the User is on the Account details page
	When the User searches for a Cohort with pending changes
	And the User clicks on 'View this cohort' button with pending changes
	And the user chooses to view Uln of the Cohort with pending changes 
	And the ULN details page is displayed with pending changes
	Then the pending changes are displayed