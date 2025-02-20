
Feature: EPR_03_ProviderRequestsAndEmployerDeclinesAddAccountRequest

@provider
@employerproviderrelationships
@deletepermission
Scenario: EPR_03_ProviderRequestsAndEmployerDeclinesAddAccountRequest
	Given a provider requests all permission from an employer
	Then the provider can not send a request to the same email
	Then the provider can not send a request to a different email from the same account
	Then the employer declines the add account request

