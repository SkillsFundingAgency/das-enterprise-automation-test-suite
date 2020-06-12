Feature: SC_Ap_Coh_03

@awaiting-fix
@supportconsole
@approvalssupportconsole
Scenario: SC_Ap_Coh_03 - Search for a unauthorised Cohort
	Given the User is logged into Support Console
	And the User is on the Account details page
	When the user tries to view another Employer's Cohort Ref
	Then unauthorised Cohort access error message is shown to the user