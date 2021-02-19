Feature: SC_BU_FiltersAction

@supportconsole
@approvalssupportconsole
Scenario: Validate Combination of filters
	Given the User is logged into Support Tools
	When user opens Pause Utility
	Then following filters should return the expected number of TotalRecords
		| EmployerName       | ProviderName						| Ukprn		| EndDate		| Uln		 | Status			| TotalRecords	|
		| ESFA LTD			 | EDUC8 TRAINING (ENGLAND) LIMITED |			|				|			 | Live				|   3000		| 
		|					 |									|			|				| 8305402974 | Paused			|   1			| 
		| ESFA LTD			 |									| 10005310	|				|			 | Waiting to Start	|   100			| 
		|					 |									|			| 17//02//2021	|			 | Live				|   300			| 
		| COMPLIANCE LIMITED |									| 10005310	|				| 8305402974 | Live				|   0			| 


