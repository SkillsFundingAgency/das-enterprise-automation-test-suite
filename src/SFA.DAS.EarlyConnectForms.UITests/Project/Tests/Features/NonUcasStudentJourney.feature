Feature: NonUcasStudentJourney
As a user I want to be able to fill online form for student interest in apprenticeship 
so that my data will be available for futher progress 

@ec-v1
@earlyconnect
@non-ucas
@regression

Scenario: Verify Non Ucas Student journey for NorthEast Region
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit

@ec-v1
@earlyconnect
@non-ucas
@alreadyusedemail
@regression

Scenario: Verify Non Ucas Student journey for already used email for NorthEast Region
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter an already used email
	Then I get the Already Completed Form Page

@ec-v1
@earlyconnect
@non-ucas
@ec-links-verification-01
@regression

Scenario: Verify How Apprenticeships Work link for Non Ucas Student
	Given I am on the landing page for a region
	And I selected the 'How apprenticeships work' link
	Then I am navigated to "Become an apprentice" page

@ec-v1
@earlyconnect
@non-ucas
@ec-links-verification-01
@regression

Scenario: Verify Find an Apprenticeship link for Non Ucas Student
	Given I am on the landing page for a region
	And I selected the 'Find an apprenticeship' link
	Then I am navigated to "Find an apprenticeship" page

@ec-v1
@earlyconnect
@non-ucas
@ec-links-verification-01
@regression

Scenario: Verify Back buttons
	Given I am on the landing page for a region
	And I selected North East Advisor Page
	And I enter valid details
	And I answer the triage questions up to the Support Page
	Then I can navigate back to the first question

@ec-v1
@earlyconnect
@regression
@non-ucas
@ignore
#Lancashire region and London region is paused till January 2025
Scenario: Verify Non Ucas Student journey for Lancashire Region
	Given I am on the landing page for a region
	And I selected Lancashire Advisor Page
	And I enter valid details
	And I answer the triage questions related to me
	Then I check my answers, accept and submit