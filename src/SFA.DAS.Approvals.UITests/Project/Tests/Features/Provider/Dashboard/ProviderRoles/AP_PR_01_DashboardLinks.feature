Feature: AP_PR_01_DashboardLinks

@Pasproviderrole
Scenario Outline: Verify login for user can access and update notification settings
	Given the provider logs in as a <User>
	When the user navigates to notification settings page
	Then the user is able to choose to receive notification emails
	And the user is able to choose No notification emails

Examples:
	| User						|
	| Viewer					|
	| Contributor				|
	| Contributor with approval	|
	| Account Owner				|

@Pasproviderrole
Scenario Outline: Verify login for user can access organisations and agreements
	Given the provider logs in as a <User>
	Then the user can view organisations and agreements
	
Examples:
	| User						|
	| Viewer					|
	| Contributor				|
	| Contributor with approval	|
	| Account Owner				|