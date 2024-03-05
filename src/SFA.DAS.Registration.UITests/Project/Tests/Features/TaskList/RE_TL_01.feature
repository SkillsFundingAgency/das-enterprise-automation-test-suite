@donotexecuteinparallel

Feature: RE_TL_01

Create Account by completing one task at a time

@regression
@registration
@addnonlevyfunds
Scenario: RE_TL_01_Create Account by completing one task at a time
	Given user logs into stub
	Then User is prompted to enter first and last name
	And user can amend name before submitting it
	When user adds name successfully to the account
	Then user can change user details from the task list
	When user <CanAddPAYE> add PAYE details
	When user <CanSetAccountName> set account name
	When user <CanSignEmployerAgreement> accept the employer agreement
	When user <CanAddTrainingProvider> add training provider
	When user <CanGrantProviderPermissions> grant training provider permissions
	When user logs out and log back in
	Then user can resume employer registration journey

	
Examples:
	| CanAddPAYE | CanSetAccountName | CanSignEmployerAgreement | CanAddTrainingProvider | CanGrantProviderPermissions |
	| can		 | cannot			 | cannot				    | cannot                 | cannot					   |