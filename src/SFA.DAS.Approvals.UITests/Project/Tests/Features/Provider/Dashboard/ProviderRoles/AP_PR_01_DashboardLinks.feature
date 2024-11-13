Feature: AP_PR_01_DashboardLinks

@approvals
@regression
@pasproviderrole
Scenario Outline: Verify login for user can access and update notification settings
	Given the provider logs in as a <UserRole>
	When the user navigates to notification settings page
	Then the user is able to choose to receive notification emails
	And the user is able to choose No notification emails

Examples:
	| UserRole                |
	| Viewer                  |
	| Contributor             |
	| ContributorWithApproval |
	| AccountOwner            |