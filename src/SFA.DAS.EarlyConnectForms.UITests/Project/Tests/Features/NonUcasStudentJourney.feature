Feature: NonUcasStudentJourney
As a user I want to be able to fill online form for student interest in apprenticeship 
so that my data will be available for futher progress 

@ec-v1
@earlyconnect
@regression

Scenario: Verify Non Ucas Student journey for NorthEast Region
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit

@ec-v1
@earlyconnect
@alreadyusedemail
@regression

Scenario: Verify Non Ucas Student journey for already used email for NorthEast Region
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter an already used email
	Then I get the Already Completed Form Page

@ec-v1
@earlyconnect
@regression
@ignore
#Lancashire region and London region is paused till January 2025
Scenario: Verify Non Ucas Student journey for Lancashire Region
	Given I am on the landing page for a region
	And I selected Lancashire Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit