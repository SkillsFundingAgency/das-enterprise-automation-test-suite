Feature: RV2_E_RA_02

@raa-v2
@raa-v2e
@regression
@recruitmentapikey
Scenario: RV2_E_RA_02 - Renew Employer Recruitment Sandbox API Key
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the Recruitment API list page
	When the employer selects Recruitment Sandbox API from the list
	Then the employer can renew the API key