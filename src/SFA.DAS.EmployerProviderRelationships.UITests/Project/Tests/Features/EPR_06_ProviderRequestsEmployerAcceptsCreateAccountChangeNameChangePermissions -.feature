Feature: EPR_06_ProviderRequestsEmployerAcceptsCreateAccountChangeNameChangePermissions

@provider
@addlevyfunds
@createemployeraccount
@singleorgaorn
@regression
@providerleadregistration
@employerproviderrelationships
@deleterequest
Scenario: EPR_06_ProviderAddAccountChangesNameEmployerAcceptsandChangesName
	Given a provider requests employer to create account with updated name and requests only RecruitApprenticeButWithEmployerReview
    Then the employer accepts the create account request