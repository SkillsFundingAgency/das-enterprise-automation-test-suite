Feature: EF_Nav_01

@employerfinance
Scenario: EF_Nav_01_Navigate to EAS sub sites from Finance Page
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then the employer can navigate to home page
	And the employer can navigate to recruitment page
	And the employer can navigate to apprentice page
	And the employer can navigate to your team page
	And the employer can navigate to account settings page
	And the employer can navigate to rename account settings page
	And the employer can navigate to change your password settings page
	And the employer can navigate to change your email address settings page
	And the employer can navigate to notification settings page
	And the employer can navigate to help settings page