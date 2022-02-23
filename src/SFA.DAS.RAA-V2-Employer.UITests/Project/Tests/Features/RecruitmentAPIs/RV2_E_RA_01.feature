Feature: RV2_E_RA_01

@raa-v2
@raa-v2e
@regression
Scenario: RV2_E_RA_01 - Renew Employer Recruitment API Key
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the Recruitment API list page
	When the employer selects Recruitment API from the list
	Then the employer can renew the API key