Feature: CA_INF_04

@campaigns
@influencers
@regression
Scenario: CA_INF_04 The links on Become an ambassador Page
	Given the user navigates to influencers Become an ambassador page
	Then the links are not broken
	