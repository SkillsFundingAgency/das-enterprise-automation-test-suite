Feature: FATV2_SearchTrainingAndProvider_01

@fatv2
@regression
Scenario: FATV2_STAP_01_Search for a Training and Provider
	Given the User searches with account term
	When the User chooses the first course from the Search Results page
	Then the User is able to find the Provider by location CV1 5FB for the chosen training