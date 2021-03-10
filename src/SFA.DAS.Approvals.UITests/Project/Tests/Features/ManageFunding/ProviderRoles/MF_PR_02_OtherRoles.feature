@ignore
Feature: MF_PR_02_OtherRoles

@Securefundingproviderrole
Scenario Outline: Verfiy login contributor,contributor with approval and account owner  
	Given the provider logs in as '<User>'
	And the user can delete reservation 
	Then the user can create reservation 
	And the user can add an apprentice 
	
Examples:
	| User					    |
	| Contributor		        |
	| Contributor with approval |
	| Account Owner             |
