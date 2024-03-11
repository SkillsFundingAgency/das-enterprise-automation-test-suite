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
	When user <DoesAddPAYE> add PAYE details
	When user <CanSetAccountName> set account name and <DoesSetAccountName>
	When user <CanSignEmployerAgreement> accept the employer agreement and <DoesSignEmployerAgreement>
	When user <CanAddTrainingProvider> add training provider and <DoesAddTrainingProvider>
	When user <CanGrantProviderPermissions> grant training provider permissions and <DoesGrantProviderPermissions>
	When user logs out and log back in
	Then user can resume employer registration journey

	
Examples:
	| DoesAddPAYE | CanSetAccountName | DoesSetAccountName | CanSignEmployerAgreement | DoesSignEmployerAgreement | CanAddTrainingProvider | DoesAddTrainingProvider | CanGrantProviderPermissions | DoesGrantProviderPermissions |
	| doesn't     | cannot            | doesn't            | cannot                   | doesn't                   | cannot                 | doesn't                 | cannot                      | doesn't                      |