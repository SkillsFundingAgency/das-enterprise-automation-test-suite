Feature: RV2_Nav_01

@raa-v2
Scenario: RV2_Nav_01_Navigate to EAS sub sites from Recruit Page
	When the Employer navigates to 'Recruit' Page
	Then the employer can navigate to home page
	Then the employer can navigate to finance page
	And the employer can navigate to apprentice page
	And the employer can navigate to your team page
	And the employer can navigate to account settings page
	And the employer can navigate to rename account settings page
	And the employer can navigate to change your password settings page
	And the employer can navigate to change your email address settings page
	And the employer can navigate to notification settings page
	And the employer can navigate to help settings page