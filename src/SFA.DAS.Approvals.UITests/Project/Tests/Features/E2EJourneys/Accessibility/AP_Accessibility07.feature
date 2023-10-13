@accessibility
@registration
Feature: AP_E2E_ACC_Accessibility07
Navigation journey through EAS and PAS 
 
@addnonlevyfunds
@providerleadregistration
Scenario: AP_E2E_ACC_07 Provider Lead Registration
	Given the provider invites an employer
	Then the invited employer status is "Account creation not started"
	When the employer sets up the user
	Then the invited employer status is "Account creation started"
	When the employer adds PAYE from TaskList Page
	Then the invited employer status is "PAYE scheme added"
	When the employer signs the agreement
	Then the invited employer status is "Legal agreement accepted"
