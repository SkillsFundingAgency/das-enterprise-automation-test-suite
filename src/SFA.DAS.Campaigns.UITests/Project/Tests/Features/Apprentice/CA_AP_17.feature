Feature: CA_AP_17

@campaigns
@apprentice
@regression
Scenario: CA_AP_17 Check Are ApprenticeShip Right For You Page
	Given the user navigates to Are ApprenticeShip Right For You Page
	Then check that RealStories Page loads
	Then the links are not broken
