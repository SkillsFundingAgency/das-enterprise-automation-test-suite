
Feature: EPR_02_ProviderInviteEmployer

@employerproviderrelationships
@deletepermission
Scenario: EPR_02_ProviderInviteEmployer
	Given a provider requests all permission from an employer
	Then the employer accepts the request
