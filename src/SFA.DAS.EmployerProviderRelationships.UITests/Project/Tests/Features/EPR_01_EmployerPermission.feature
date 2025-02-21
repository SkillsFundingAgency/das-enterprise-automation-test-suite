
@provider
@donotexecuteinparallel
Feature: EPR_01_EmployerGrantPermission

@employerproviderrelationships
@deletepermission
Scenario: EPR_01A_EmployerAddAndUpdateProviderPermissions
	Given Levy employer grants all permission to a provider
	Then the correct permissions should be displayed in the employer portal
	When the employer changes recruit apprentice permission
	Then the correct permissions should be displayed in the employer portal
	When the employer revokes all provider permissions


@employerproviderrelationships
@deletepermission
Scenario: EPR_01B_EmployerMustSelectAtLeastOnePermission
	Then an employer has to select at least one permission	

@employerproviderrelationships
@deletepermission
Scenario: EPR_01C_EmployerTrysToAddExistingProvider
	Given Levy employer grants all permission to a provider
	Then the correct permissions should be displayed in the employer portal
	And the employer is unable to add an existing provider