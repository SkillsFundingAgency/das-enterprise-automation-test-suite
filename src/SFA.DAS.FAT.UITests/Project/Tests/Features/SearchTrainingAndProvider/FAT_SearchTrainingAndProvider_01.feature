Feature: FAT_SearchTrainingAndProvider_01

@fat
@regression
Scenario: FAT_STAP_01_Search for a Training and Provider
	When the User searches with account term
	Then the User is able to choose the first training from the results displayed
	And the User is able to find the Provider by location CV1 5FB for the chosen training