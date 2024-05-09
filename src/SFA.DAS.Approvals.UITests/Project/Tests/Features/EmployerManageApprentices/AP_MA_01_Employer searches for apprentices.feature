Feature: AP_MA_01_Employer searches for apprentices
	In order to find apprentices that i wish to see
	As an employer
	I need to be able to search for apprentices

@approvals
@regression
Scenario: AP_MA_01_Employer searches for apprentices
	Given An employer has navigated to Manage your apprentice page
	When the employer filters by 'Live'
	Then the employer is presented with first page with filters applied
	And Employer is able to download the results in a csv file
	And Employer can confirm number of rows in Apprentices csv file