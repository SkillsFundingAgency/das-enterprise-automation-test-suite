Feature: NonUcasStudentJourney
As a user I want to be able to fill online form for student interest in apprenticeship 
so that my data will be available for futher progress 

@ec-v1
@earlyconnect
@regression

Scenario: EC_GAA_02_StudentSurvey_Verify Non Ucas Student journey for selected Region
	Given I am on the landing page for a region
	And I selected <County> Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit

	Examples: 
	|  County	 |
	|  Lancashire|
	|  North East|
	|  London    |
