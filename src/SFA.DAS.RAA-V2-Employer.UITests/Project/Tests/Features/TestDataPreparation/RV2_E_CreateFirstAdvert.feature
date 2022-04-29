Feature: RV2_E_CreateFirstAdvert	
	As a Levy Employer, Create First Advert
#Do not add regression or approvals tag, as these tests are meant to create data
	
Scenario Outline: RV2_E_CreateFirstAdvert Perf test data preparation
	Given the Employer creates first draft advert using '<employeremail>'

	Examples: 
	| employeremail  |
	| To Be declared |