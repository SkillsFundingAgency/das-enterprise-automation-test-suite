Feature: SC_BU_BulkPauseAndResume

@supportconsole
@approvalssupportconsole
@BulkUtility
Scenario: Bulk Pause Apprentice Records
	Given the User is logged into Support Tools
	And Opens the Pause Utility
	And Search for Apprentices using following criteria
		| EmployerName			| ProviderName | Ukprn		| EndDate	| Uln | Status	| TotalRecords	|
		| COMPLIANCE LIMITED    |              | 10005760   |			|     |			|   100			| 
	
	When User selects all records and click on Pause Apprenticeship button
	Then User should be able to pause all the live records


@supportconsole
@approvalssupportconsole
@BulkUtility
Scenario: Bulk Resume Apprentice Records
	Given the User is logged into Support Tools
	And Opens the Resume Utility
	And Search for Apprentices using following criteria
		| EmployerName			| ProviderName | Ukprn		| EndDate	| Uln | Status	| TotalRecords	|
		| COMPLIANCE LIMITED    |              | 10005760   |			|     |			|   100			| 
	
	When User selects all records and click on Resume Apprenticeship button
	Then User should be able to resume all the paused records




	