@ab
Feature: MF_PR_01_ViewOnly
	 

@mytag
Scenario: Verify login for view only user  
	Given the provider logins as a viewer
	Then the user can not reserve the funding
	And the user can not delete the reservation