Feature: EmploymentCheckE2EPayeIsNull_2

Description: In this test, Accounts api, returns a 200 response code but there is No paye scheme returned. Employment check is completed after enrichment.
			 Completion status for the check is set to 2 [Completed] and ErrorType as NinoNotFound

@api
@regression
@employmentcheckapi
Scenario: EC_API_011_PerformEmploymentCheck_PayeIsNullWith200Response
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Paye/Scheme is not found
	Then do not create an Employment Check request
	And employment check record status is '<Status>'
	And business outcome for the check is set to '<ErrorType>'

Examples:
	| TestCaseId | MinDate             | MaxDate             | Status | ErrorType    |
	| 11         | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | 2      | PAYENotFound |