@ignore
Feature: RE_PAS_PR_02

@Providerregistrationproviderrole
Scenario Outline: Provider Roles 
	Given the provider logs in as a <User>
	And the user can view invited employers
	And the user can invite an employer to setup an account

Examples:
	| User                     |
	| Contributor              |
	| ContributorWithApproval  |
	| AccountOwner             |