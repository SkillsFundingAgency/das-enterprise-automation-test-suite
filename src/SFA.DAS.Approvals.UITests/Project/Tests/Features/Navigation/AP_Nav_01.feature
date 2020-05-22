Feature: AP_Nav_01


@regression
@approvals
@approvalsnavigation
Scenario: AP_Nav_01_Navigate to EAS sub sites from Apprentice Page
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Apprentice' Page
	Then the employer can navigate to home page
	Then the employer can navigate to finance page
	And the employer can navigate to paye scheme page
	And the employer can navigate to your team page
	And the employer can navigate to your organisation and agreement page
	And the employer can navigate to account settings page
	And the employer can navigate to rename account settings page
	And the employer can navigate to change your password settings page
	And the employer can navigate to change your email address settings page
	And the employer can navigate to notification settings page
	And the employer can navigate to help settings page