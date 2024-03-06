@donotexecuteinparallel
Feature: RE_TL_02

A short summary of the feature

@regression
@registration
@addnonlevyfunds
Scenario: RE_TL_02_Add PAYE Details on task list
	Given user logs into stub
	Then User is prompted to enter first and last name
	Then user adds name successfully to the account	
	When user <DoesAddPAYE> add PAYE details
	When user <CanSetAccountName> set account name and <DoesSetAccountName>
	When user <CanSignEmployerAgreement> accept the employer agreement and <DoesSignEmployerAgreement>
	When user <CanAddTrainingProvider> add training provider and <DoesAddTrainingProvider>
	When user <CanGrantProviderPermissions> grant training provider permissions and <DoesGrantProviderPermissions>
	When user logs out and log back in
	Then user can resume employer registration journey

	
Examples:
	| DoesAddPAYE | CanSetAccountName | DoesSetAccountName | CanSignEmployerAgreement | DoesSignEmployerAgreement | CanAddTrainingProvider | DoesAddTrainingProvider | CanGrantProviderPermissions | DoesGrantProviderPermissions |
	| does		 | can               | doesn't            | cannot                   | doesn't                   | cannot                 | doesn't                 | cannot                      | doesn't                      |
	| does		 | can               | does	              | can                      | doesn't                   | cannot                 | doesn't                 | cannot                      | doesn't                      |
	| does		 | can               | does	              | can                      | does						 | can					  | doesn't                 | cannot                      | doesn't                      |
	| does		 | can               | does	              | can                      | does						 | can					  | does	                | can	                      | doesn't                      |
	