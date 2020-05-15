Feature: EF_Nav_01

@regression
@employerfinance
Scenario: EF_Nav_01_Navigate to EAS sub-sites from Finance Page
	Given the Employer logins using existing Levy Account
	When the Employer navigates to 'Finance' Page
	Then the employer can navigate to home page
	Then the employer can navigate to recruitment page
	Then the employer can navigate to apprentice page
	Then the employer can navigate to your team page
	Then the employer can navigate to account settings page