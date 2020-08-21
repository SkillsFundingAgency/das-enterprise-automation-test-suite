Feature: FATV2_SortResults_01

@FATV2
@regression
Scenario: FAT_SR_02 Verify Search Results Sorting
	Given the User searches with animal term
	When the User chooses to diplay results in 'Name' order
	Then the 'Relevance' link is displayed