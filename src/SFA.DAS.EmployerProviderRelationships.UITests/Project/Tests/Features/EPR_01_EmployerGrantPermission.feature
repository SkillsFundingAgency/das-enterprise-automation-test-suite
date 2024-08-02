
Feature: EPR_01_EmployerGrantPermission

@employerproviderrelationships
@grantpermission
Scenario: EPR_01_EmployerGrantPermission
	Given Levy employer grant all permission to a provider
	Then the provider should be added with the correct permissions