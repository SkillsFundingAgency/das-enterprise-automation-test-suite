Feature: CA_Influencers_01

@campaigns
@influencers
@regression
Scenario: CA_Influencers_01_Check Influencers Page Details
	Given the user navigates to the influencers page
	Then the links are not broken
	And the video links are not broken
	And the fire it up tile card links are not broken
	