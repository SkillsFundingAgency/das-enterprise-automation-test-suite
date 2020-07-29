@approvals
Feature: AP_Nav_03

@regression
@approvalsnavigation
Scenario: AP_Nav_03_Navigate to different links from Apprentices Page
	Given Employer navigates to Apprentices home page
	Then Standard gov.uk footer should be displayed at the bottom of the page
	And the Help widget is displayed on bottom right hand corner	
	Then 'Manage your apprentices' link should direct user to 'Manage your apprentices' page
	And 'Apprentice requests' link should direct user to 'Your cohort requests' page
	And 'Add an apprentice' link should direct user to 'Add an apprentice' page
