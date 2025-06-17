Feature: EducationalOrganisation

As a user I want to be able to search for my school on my region or enter manually 

@ec-v1
@earlyconnect
@regression
Scenario: EC_GAA_01_InvalidSchoolSearchInvalid details for school and college autosearch
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter valid details
	And I enter invalid details for school autosearch
	Then I check my answers, accept and submit
