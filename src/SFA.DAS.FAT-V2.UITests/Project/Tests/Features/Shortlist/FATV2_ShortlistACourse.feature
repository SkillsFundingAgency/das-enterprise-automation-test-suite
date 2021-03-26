Feature: FATV2_ShortlistACourse

@mytag
Scenario: FATV2_SAC_01_Shortlist A Course With And Without Location
	Given the User searches with adult term
	And the User chooses the first course from the Search Results page
	And the User is able to find the Provider by location CV1 2WT for the chosen training
	When user shortlists with a location
	And user shortlists without a location
