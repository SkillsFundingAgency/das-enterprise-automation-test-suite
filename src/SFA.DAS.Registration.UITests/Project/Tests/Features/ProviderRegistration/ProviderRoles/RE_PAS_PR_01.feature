Feature: RE_PAS_PR_01	

@Providerregistrationproviderrole
Scenario: Verify viewer login 
	Given the provider logs in as a Viewer
	And the user can view invited employers
	And the user cannot invite an employer to setup an account