Feature: RE_TL_03

A short summary of the feature

@regression
@registration
@addnonlevyfunds
Scenario: RE_TL_03_Set Account Name on task list
	Given user logs into stub
	Then User is prompted to enter first and last name
	Then user adds name successfully to the account	
	When user <DoesAddPAYE> add PAYE details
	When user <CanSetAccountName> set account name and <DoesSetAccountName>
	Then user can update account name
	When user <CanSignEmployerAgreement> accept the employer agreement and <DoesSignEmployerAgreement>
	When user <CanAddTrainingProvider> add training provider and <DoesAddTrainingProvider>
	When user logs out and log back in
	Then user can resume employer registration journey
	
Examples:
	| DoesAddPAYE | CanSetAccountName | DoesSetAccountName | CanSignEmployerAgreement | DoesSignEmployerAgreement | CanAddTrainingProvider | DoesAddTrainingProvider | 
	| does		  | can				  | does			   | can					  | doesn't                   | cannot                 | doesn't                 |