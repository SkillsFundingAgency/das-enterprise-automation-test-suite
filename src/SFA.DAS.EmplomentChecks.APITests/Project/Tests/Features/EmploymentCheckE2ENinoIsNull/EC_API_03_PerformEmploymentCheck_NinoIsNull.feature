Feature: EmploymentCheckE2ENinoIsNull

@api
@regression
@employmentcheckapi
Scenario: EC_API_003_PerformEmploymentCheck_NinoIsNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Nino is not found
	Then do not create an Employment Check request
	And employment check record status is '<Status>'
	And business outcome for the check is set to '<ErrorType>'

Examples:
	| TestCaseId | MinDate             | MaxDate             | Status | ErrorType    |
	| 3          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | 2      | NinoNotFound |