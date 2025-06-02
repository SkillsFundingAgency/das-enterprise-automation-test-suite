Feature: PR_PAS_01_ProviderPortalNavigation

@provider
@regression
@pasproviderrole
Scenario: PR_PAS_01_ProviderPortalNavigation
	Given the provider logs in as a <UserRole>
	Then user can access Notification Settings page
	And user can access Orgs And Agreements page
	And user can access Help page
	And user can access Feedback page
	And user can access Privacy Statement page
	And user can access Cookies page
	And user can access Terms Of Use page
	And user can signout from their account

Examples:
	| UserRole                |
	| Viewer                  |
	| Contributor             |
	| ContributorWithApproval |
	| AccountOwner            |