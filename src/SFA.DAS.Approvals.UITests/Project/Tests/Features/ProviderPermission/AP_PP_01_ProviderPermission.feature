Feature: AP_PP_01_ProviderPermission
An employer can grant and revoke create cohort permission to a provider

@deletepermission
@CreateCohortPermission
#@approvals - This test case has now been migrated to Playwright solution
Scenario: AP_PP_01 Employer grant and revoke Create Cohort permission to a provider
	Given Employer grant create cohort permission to a provider
	Then Provider can Create Cohort
	When Employer revoke create cohort permission to a provider
	Then Provider cannot Create Cohort