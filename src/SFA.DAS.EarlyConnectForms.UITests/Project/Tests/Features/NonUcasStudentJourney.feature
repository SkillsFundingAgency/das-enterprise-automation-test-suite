Feature: NonUcasStudentJourney
As a user I want to be able to fill online form for student interest in apprenticeship 
so that my data will be available for futher progress 

@ec-v1
@earlyconnect
@regression

Scenario: EC_GAA_02_A_StudentSurvey - Non Ucas Student journey for NorthEast Region
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit

@ec-v1
@earlyconnect
@regression
Scenario: EC_GAA_02_B_StudentSurvey - Non Ucas Student journey for Lancashire Region
	Given I am on the landing page for a region
	And I selected Lancashire Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit

Scenario: EC_GAA_02_C_StudentSurvey - Non Ucas Student journey for Greater London Region
	Given I am on the landing page for a region
	And I selected Greater London Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit