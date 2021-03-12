@ignore
Feature: MF_PR_01_ViewOnly
	 

@Securefundingproviderrole
Scenario: Verify login for view only user  
	Given the provider logs in as a Viewer
	Then the user can not reserve the funding
	And the user can not delete the reservation 
	And the user can not add an apprentice 
