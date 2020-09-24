Feature: FATV2_SearchTrainingByLocation_02

@fatv2
@regression
Scenario: FATV2_STBL_02_Search for Training by Postcode
	Given the User searches with account term
	When the User chooses the first course from the Search Results page
	Then the User is able to find the Provider by location CV1 5FB for the chosen training