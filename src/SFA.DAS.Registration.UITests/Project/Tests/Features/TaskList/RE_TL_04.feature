Feature: RE_TL_04

A short summary of the feature

@regression
@registration
@addnonlevyfunds
Scenario: RE_TL_04_Employer Agreement on task list
	Given user logs into stub
	Then User is prompted to enter first and last name
	Then user adds name successfully to the account	
	When user <DoesAddPAYE> add PAYE details
	When user <CanSetAccountName> set account name and <DoesSetAccountName>
	When user acknowledges the employer agreement
	Then user can change user details from the task list
	Then user can update account name
	When user <CanAddTrainingProvider> add training provider and <DoesAddTrainingProvider>, the user <DoesGrantProviderPermissions> grant training provider permissions
	When user logs out and log back in
	Then user accepts agreement having already acknowledged
		
Examples:
	| DoesAddPAYE | CanSetAccountName | DoesSetAccountName | CanSignEmployerAgreement | DoesSignEmployerAgreement | CanAddTrainingProvider | DoesAddTrainingProvider | DoesGrantProviderPermissions |
	| does        | can               | does               | can                      | does                      | can                    | does                    | does                         |
