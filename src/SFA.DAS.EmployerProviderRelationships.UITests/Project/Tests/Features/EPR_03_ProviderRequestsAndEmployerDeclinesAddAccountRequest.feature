
Feature: EPR_03_ProviderRequestsAndEmployerDeclinesAddAccountRequest

@employerproviderrelationships
@deletepermission
Scenario: EPR_03_ProviderRequestsAndEmployerDeclinesAddAccountRequest
	Given a provider requests all permission from an employer
	Then the provider can not send an invite to a different email from same account
	Then the employer declines the add account request

