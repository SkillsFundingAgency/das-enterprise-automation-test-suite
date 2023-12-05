Feature: RE_PR_02

@regression
@registration
@addnonlevyfunds
@providerleadregistration
Scenario: RE_PR_02 Provider Lead Registration
	Given the provider invites an employer
	Then the invited employer status is "Account creation not started"
	When the provider resends the invite after editing details
	Then the email address is not editable
	When the employer sets up the user
	Then the invited employer status is "Account creation started"
	And view status "Account creation started:" is "today"
	And view status "PAYE scheme added:" is "PAYE scheme not added"
	And view status "Legal agreement accepted:" is "Legal agreement not accepted"
	When the employer adds PAYE from TaskList Page
	Then the invited employer status is "PAYE scheme added"
	And view status "Account creation started:" is "today"
	And view status "PAYE scheme added:" is "today"
	And view status "Legal agreement accepted:" is "Legal agreement not accepted"
	When the employer signs the agreement
	Then the invited employer status is "Legal agreement accepted"
	And view status "Account creation started:" is "today"
	And view status "PAYE scheme added:" is "today"
	And view status "Legal agreement accepted:" is "today"