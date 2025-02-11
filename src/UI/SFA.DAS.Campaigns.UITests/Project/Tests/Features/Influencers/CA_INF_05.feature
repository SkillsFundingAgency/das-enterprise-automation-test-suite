Feature: CA_INF_05

@campaigns
@influencers
@regression
Scenario: CA_INF_05_Check Browse Apprenticeship Page And Search For An Apprenticeship
	Given the user navigates to the browse apprenticeship page
	Then the links are not broken
	And the user can search for an apprenticeship