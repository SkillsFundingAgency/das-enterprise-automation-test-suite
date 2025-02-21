Feature: FAARandomSearch

User searches for a vacancy using without populating search fields

@faa
@raa
Scenario: FAA_USFV_01 User searches for a vacancy at random
	Given the candidate can login in to faa
	When the user does a search without populating search fields
	Then the user is presented with search results
