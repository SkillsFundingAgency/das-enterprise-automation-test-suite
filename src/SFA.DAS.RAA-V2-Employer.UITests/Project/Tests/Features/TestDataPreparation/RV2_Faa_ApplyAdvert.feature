Feature: RV2_Faa_ApplyAdvert	
	As a applicant, apply for raav2 advert 
#Do not add regression or approvals tag, as these tests are meant to create data
	
Scenario Outline: RV2_Faa_ApplyAdvert Perf test data preparation
	Given the Applicant can apply for an advert in FAA using '<advertrefnum>', title as '<adverttitle>'

	Examples: 
	| advertrefnum   | adverttitle    |
	| To Be declared | To Be declared |
