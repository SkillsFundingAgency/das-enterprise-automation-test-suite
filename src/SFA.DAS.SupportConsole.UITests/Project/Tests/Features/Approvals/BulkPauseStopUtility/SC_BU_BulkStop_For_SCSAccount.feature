Feature: SC_BU_BulkStop_For_SCSAccount


@supportconsole
@approvalssupportconsole
@BulkUtility
Scenario: Bulk Stop Apprentice SCS Role
  Given the SCS User is logged into Support Tools
  And Opens the Stop Utility
  And Search for Apprentices using following criteria
		| EmployerName			| ProviderName | Ukprn		| EndDate	| Uln | Status	| TotalRecords	|
		| COMPLIANCE LIMITED    |              | 10005310   |			|     |			|   25			| 
		
	When User selects all records and click on Stop Apprenticeship button
	Then User should be able to stop all the records