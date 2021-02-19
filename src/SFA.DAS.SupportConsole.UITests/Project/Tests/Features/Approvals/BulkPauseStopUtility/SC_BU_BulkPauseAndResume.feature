Feature: SC_BU_BulkPauseAndResume


@supportconsole
@approvalssupportconsole
Scenario: Bulk Pause and then Resume Apprentice Records
	Given the User is logged into Support Tools
	And Opens the Pause Utility
	And Search for Apprentices using following criteria
		| EmployerName | ProviderName | Ukprn		| EndDate	| Uln | Status	| TotalRecords	|
		| ESFA LTD     |              | 10005310    |			|     | Live	|   3000		| 
	
	When User selects all records and click on Pause Apprenticeship button
	#Then Pause apprenticeships page is displayed with 10 records
	#And User should be able to pause them all




	