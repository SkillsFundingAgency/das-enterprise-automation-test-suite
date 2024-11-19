
Feature: EPR_02_ProviderAddAccountAndAcceptDeclineNewPermissionRequests

@employerproviderrelationships
@deletepermission
@acceptrequest
@deleterequest
Scenario: EPR_02_ProviderAddAccountAndAcceptDeclineNewPermissionRequests
	Given a provider requests all permission from an employer
	Then the employer accepts the add account request
	When the provider update the permission
	Then the employer declines the update permission request
	When the provider update the permission again
	Then the employer accepts the update permission request
	Then the provider should be shown a shutter page where relationship already exists