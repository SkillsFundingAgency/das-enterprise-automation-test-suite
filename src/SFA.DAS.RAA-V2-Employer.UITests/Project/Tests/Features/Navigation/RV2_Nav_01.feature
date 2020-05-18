Feature: RV2_Nav_01

@regression
@raa-v2
Scenario: RV2_Nav_01_Navigate to EAS sub-sites from Recruit Page
	When the Employer navigates to 'Recruit' Page
	Then the employer can navigate to home page
	Then the employer can navigate to finance page
	Then the employer can navigate to apprentice page
	Then the employer can navigate to your team page
	Then the employer can navigate to account settings page