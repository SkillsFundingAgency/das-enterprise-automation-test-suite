Feature: FAT_SortResults_01

@fat
@regression
Scenario: FAT_SR_01 Verify Search Results Sorting
	Given the User searches with account term
	When the User chooses to diplay results in ascending order of Apprenticeship Level
	Then the results are displayed in ascending order
	When the User chooses to diplay results in descending order of Apprenticeship Level
	Then the results are displayed in descending order