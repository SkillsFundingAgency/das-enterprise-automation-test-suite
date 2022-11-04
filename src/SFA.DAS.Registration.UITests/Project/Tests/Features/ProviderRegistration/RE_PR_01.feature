Feature: RE_PR_01

@regression
@registration
@addnonlevyfunds
@providerleadregistration
Scenario: RE_PR_01 Provider Lead Registration
	Given the provider invites an employer
	Then the invited employer status is "Account creation not started"
	When the employer sets up the user
	Then the invited employer status is "Account creation started"
	When the employer adds PAYE from Account Home Page
	Then the invited employer status is "PAYE scheme added"
	When the employer signs the agreement
	Then the invited employer status is "Legal agreement accepted"