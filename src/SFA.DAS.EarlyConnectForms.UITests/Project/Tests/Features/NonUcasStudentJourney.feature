Feature: NonUcasStudentJourney
As a user I want to be able to fill online form for student interest in appretiship 
so that my data will be available for futher progress 

@ec-v1
@earlyconnect-ui
@regression
Scenario Outline: Verify Non Ucas Student journey
	Given I am on the landing page for a region '<lepCode>'

	Examples: 
	  | lepCode   |
	  | E37000051 |

Scenario: Verify Ucas Student journey
	Given I am on the landing page for a region
	And I enter valid details
	And I answer the triage questions related to me

	
