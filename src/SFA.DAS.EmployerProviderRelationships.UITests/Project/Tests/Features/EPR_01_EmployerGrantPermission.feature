
Feature: EPR_01_EmployerGrantPermission

@employerproviderrelationships
Scenario: EPR_01_EmployerGrantPermission
	Given Levy employer grant create cohort permission to a provider
	Then the provider should be added with the correct permissions