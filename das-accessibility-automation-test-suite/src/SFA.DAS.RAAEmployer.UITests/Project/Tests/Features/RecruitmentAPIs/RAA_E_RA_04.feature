@raa
@raaemployer
@regression
@recruitmentapikey
Feature: RAA_E_RA_04

Scenario: RAA_E_RA_04_01 - View display advert api dev hub pages
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the developer get started page
	When the employer selects 'Display Advert API' link
	Then the employer can view the 'Display advert API' page

Scenario: RAA_E_RA_04_02 - View recruitment api dev hub pages
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the developer get started page
	When the employer selects 'Recruitment API' link
	Then the employer can view the 'Recruitment API' page

Scenario: RAA_E_RA_04_03 - Sign in to api dev hub
	Given the Employer navigates to 'Recruit' Page
	And the employer selects the developer get started page
	When the employer signs in to dev hub
	Then the employer can view the 'API list' page