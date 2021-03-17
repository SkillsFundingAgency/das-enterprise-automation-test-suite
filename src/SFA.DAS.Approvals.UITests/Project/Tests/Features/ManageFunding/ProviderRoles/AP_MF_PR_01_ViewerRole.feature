@ignore
Feature: MF_PR_01_ViewerRole

@Securefundingproviderrole
Scenario: Verify login for Viewer user can not delete a reservation
	Given the provider logs in as a Viewer
	And a reservation exists
	Then the user can not delete the reservation

@Securefundingproviderrole
Scenario: Verify login for Viewer user can not add an apprentice
	Given the provider logs in as a Viewer
	And a reservation exists
	Then the user can not add an apprentice

@Securefundingproviderrole
Scenario: Verify login for Viewer user can not reserve some funding
	Given the provider logs in as a Viewer
	Then the user can not reserve the funding