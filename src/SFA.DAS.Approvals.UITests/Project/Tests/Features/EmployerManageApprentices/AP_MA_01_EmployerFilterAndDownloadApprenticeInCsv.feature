Feature: AP_MA_01_EmployerFilterAndDownloadApprenticeInCsv

@approvals
@regression
@setdownloadsdirectory
Scenario: AP_MA_01_EmployerFilterAndDownloadApprenticeInCsv
	Given An employer has navigated to Manage your apprentice page
	When the employer filters by 'Live'
	Then the employer is presented with first page with filters applied
	And Employer is able to download the results in a csv file
	And Employer can confirm number of rows in Apprentices csv file