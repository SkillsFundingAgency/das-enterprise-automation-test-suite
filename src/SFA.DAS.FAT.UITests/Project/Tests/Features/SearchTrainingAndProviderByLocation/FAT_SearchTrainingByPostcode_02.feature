Feature: FATSearchTrainingByLocation_02

@fat
@regression
Scenario: FATSTBL_02_Search for Training by Postcode
	Given the User searches with account term
	When the User chooses the first course from the Search Results page
	Then the User is able to find the Provider by location CV1 5FB for the chosen training