@approvals
Feature: ProviderPermission
An employer can grant and revoke create cohort permission to a provider

@regression
@CreateCohortPermission
Scenario: Employer grant and revoke Create Cohort permission to a provider
	Given Employer grant create cohort permission to a provider
	Then Provider can Create Cohort
	When Employer revoke create cohort permission to a provider
	Then Provider cannot Create Cohort