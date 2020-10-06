Feature: FATV2_SearchTrainingByLocation_01

@fatv2
@regression
Scenario: FATV2_STBL_01_Search for Training By Area
	Given the User searches with adult term
	When the User chooses the first course from the Search Results page
	Then the User is able to find the Provider by location Camden for the chosen training
	And the User is able to select the Provider for the chosen training