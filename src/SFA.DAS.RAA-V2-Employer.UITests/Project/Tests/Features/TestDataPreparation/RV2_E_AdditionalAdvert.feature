Feature: RV2_E_AdditionalAdvert	
	As a Levy Employer, Create additional Advert
#Do not add regression or approvals tag, as these tests are meant to create data

@raa-v2e
Scenario Outline: RV2_E_AdditionalAdvert and Approve Perf test data preparation
	Given the Employer creates additional using '<employeremail>'
	And the Reviewer Approves the vacancy

	Examples: 
	| employeremail  |
	| To Be declared |
