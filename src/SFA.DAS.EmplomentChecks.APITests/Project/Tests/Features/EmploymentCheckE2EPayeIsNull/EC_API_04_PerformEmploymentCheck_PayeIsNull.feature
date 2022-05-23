Feature: EmploymentCheckE2EPayeIsNull

Description: In this test, Accounts api, returns a 404 response code. Employment check is completed after enrichment as there is no PAYE Scheme returned.
			 Completion status for the check is set to 2 [Completed] and ErrorType as NinoNotFound

@api
@regression
@employmentcheckapi
Scenario: EC_API_004_PerformEmploymentCheck_PayeIsNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Paye/Scheme is not found
	Then do not create an Employment Check request
	And employment check record status is '<Status>'
	And business outcome for the check is set to '<ErrorType>'

Examples:
	| TestCaseId | MinDate             | MaxDate             | Status | ErrorType    |
	| 4          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | 2      | PAYENotFound |