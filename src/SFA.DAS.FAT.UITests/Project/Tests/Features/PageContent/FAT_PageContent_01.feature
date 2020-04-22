Feature: FAT_PageContent_01

@fat
@regression
Scenario: FAT_PC_01 Verify Search Results page content
	When the User navigates to the Search Results page
	Then the Search Results page features are displayed