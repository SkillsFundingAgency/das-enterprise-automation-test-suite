Feature: RV2_E_ProviderPermission	
	As a Levy Employer, grant provider permission to allow create advert
#Do not add regression or approvals tag, as these tests are meant to create data

@perftest
@donottakescreenshot
Scenario Outline: RV2_E_ProviderPermission Perf test data preparation
	Given the Employer '<employeremail>' grants permission to a provider 
	| ukprn          | providername   |
	| To Be declared | To Be declared |
	
	Examples: 
	| employeremail  |
	| To Be declared |
