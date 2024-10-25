
Feature: EPR_02_ProviderRequestsEmployerAccept

@employerproviderrelationships
@deletepermission
@acceptrequest
Scenario: EPR_02_ProviderRequestsEmployerAccept
	Given a provider requests all permission from an employer
	Then the employer accepts the request
	When the provider update the permission
	Then the employer accepts the updated request
	Then the provider should be shown a shutter page where relationship already exists