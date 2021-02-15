Feature: SC_BU_BulkPauseAndResume
	

@supportconsole
@approvalssupportconsole
Scenario: Bulk Pause and then Resume Apprentice Records
	Given the User is logged into Support Tools
	And Open Pause utility
	When selects Search by <EmployerName> and <ProviderName>
	Then <TotalRecords> are retreived
	#When User selects all records and click on Pause Apprenticeship button
	#Then Pause apprenticeships page is displayed with 10 records
	#And User should be able to pause them all

Examples: 
	| EmployerName				| ProviderName													|  TotalRecords		| 
	| COMPLIANCE LIMITED		| SOUTHAMPTON ENGINEERING TRAINING ASSOCIATION LIMITED (THE)	| 100				| 