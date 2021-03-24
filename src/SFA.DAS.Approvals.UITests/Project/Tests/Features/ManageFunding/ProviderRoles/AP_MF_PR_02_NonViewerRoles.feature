@ignore
Feature: MF_PR_02_NonViewerRoles

@Securefundingproviderrole
Scenario Outline: Verfiy login for non Viewer user
	Given the provider logs in as a <User>
	Then the user can create reservation 
	And the user can add an apprentice 
	And the user can delete reservation 
	
# waiting for new roles to be allowed in Approvals for Contributor and ContributorWithApproval

Examples:
	| User						|
	| Contributor				|
	| ContributorWithApproval	|
	| AccountOwner				|
