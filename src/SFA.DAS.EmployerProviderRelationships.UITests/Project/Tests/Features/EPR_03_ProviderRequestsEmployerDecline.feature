
Feature: EPR_03_ProviderRequestsEmployerDecline

@employerproviderrelationships
@deletepermission
Scenario: EPR_03_ProviderRequestsEmployerDecline
	Given a provider requests all permission from an employer
	Then the employer declines the request
	When the provider update the permission
	Then the employer accepts the updated request
