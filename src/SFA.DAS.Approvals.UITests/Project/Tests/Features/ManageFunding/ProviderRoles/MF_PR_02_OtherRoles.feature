@ab
Feature: MF_PR_02_OtherRoles

@mytag
Scenario Outline: Verfiy login contributor,super contributor and super user  
	Given the provider Navigates to "wwww.google.com"
	And logs in as <User> user
	#Given A Provider has navigated to Manage your apprentice page
	Then the user can create reservation 
	#And the user can delete reservation 
	#And the user can add an apprentice 
	
Examples:
	| User              |
	| Contributor       |
	| Super Contributor |
	| Account Owner     |
