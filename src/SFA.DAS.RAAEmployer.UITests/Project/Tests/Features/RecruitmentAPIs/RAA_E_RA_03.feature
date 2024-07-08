Feature: RAA_E_RA_03

@raa
@raaemployer
@regression
@recruitmentapikey
Scenario: RAA_E_RA_03 - Renew Employer Display API Key
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the Recruitment API list page
	When the employer selects Display API from the list
	Then the employer can renew the API key