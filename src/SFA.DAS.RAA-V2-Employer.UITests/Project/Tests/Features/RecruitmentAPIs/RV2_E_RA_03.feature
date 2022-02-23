Feature: RV2_E_RA_03

@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_RA_03 - Renew Employer Display API Key
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the Recruitment API list page
	When the employer selects Display API from the list
	Then the employer can renew the API key