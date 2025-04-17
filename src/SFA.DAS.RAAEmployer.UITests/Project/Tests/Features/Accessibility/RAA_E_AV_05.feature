Feature: RAA_E_AC_05

@raa
@raaemployer
@regression
Scenario: RAA_E_AC_05_01 - Create advert by navigating to all location types and wage types
	Given the Employer creates an advert with "all location types" work location and 'all wage types' wage type
	When the Employer navigates to 'Recruit dashboard' Page
	Then the employer selects Recruitment API from the list
	When the employer navigates to Adverts page
	Then the employer selects the 'Manage your emails' link
