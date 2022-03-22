Feature: EmploymentCheckE2ENinoAndPayeAreNull

@api
@regression
@employmentcheckapi
Scenario: EC_API_005_PerformEmploymentCheck_NinoAndPayeAreNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Nino and Paye/Scheme are not found
	Then do not create an Employment Check request
	And employment check record status is '<Status>'
	And business outcome for the check is set to '<ErrorType>'

Examples:
	| TestCaseId | MinDate             | MaxDate             | Status | ErrorType           |
	| 5          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | 2      | NinoAndPAYENotFound |