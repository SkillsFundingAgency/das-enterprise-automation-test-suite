
Feature: EPR_02_ProviderAddAccountAndAcceptDeclineNewPermissionRequests

@provider
@employerproviderrelationships
@deletepermission
@acceptrequest
@deletepermission
@deleterequest
Scenario: EPR_02_ProviderAddAccountAndAcceptDeclineNewPermissionRequests
	Given a provider requests all permission from an employer
	Then the employer accepts the add account request
	When the provider updates the permission to NoToAddApprenticeRecords YesRecruitApprenticesButEmployerWillReview
	Then the employer declines the update permission request
	When the provider updates the permission to NoToAddApprenticeRecords YesRecruitApprenticesButEmployerWillReview
	Then the employer accepts the update permission request
	When the provider updates the permission to NoToAddApprenticeRecords YesRecruitApprentices
	Then the employer accepts the update permission request
	When the provider updates the permission to YesAddApprenticeRecords YesRecruitApprentices
	Then the employer accepts the update permission request
	When the provider updates the permission to YesAddApprenticeRecords YesRecruitApprenticesButEmployerWillReview
	Then the employer accepts the update permission request
	When the provider updates the permission to YesAddApprenticeRecords NoToRecruitApprentices
	Then the employer accepts the update permission request
	Then the provider should be shown a shutter page where relationship already exists