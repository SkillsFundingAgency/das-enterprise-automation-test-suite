Feature: FATV2_FilterResults_01

@fat
@regression
Scenario: FATV2_FR_01 Verify Search Results filtering
	Given the User navigates to the Search Results page
	When the User selects level 2 to filter results
	Then only the level 2 Search Results are displayed
	When the User selects level 5 to filter results
	Then only the level 5 Search Results are displayed