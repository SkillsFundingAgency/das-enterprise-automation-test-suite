@ab
Feature: MF_PR_02_OtherRoles

@mytag
Scenario Outline: Verfiy login contributor,super contributor and super user  
	Given the provider logs in as '<User>'
	And the user can delete reservation 
	Then the user can create reservation 
	And the user can add an apprentice 
	
Examples:
	| User              |
	| Contributor       |
	| Super Contributor |
	| Account Owner     |
