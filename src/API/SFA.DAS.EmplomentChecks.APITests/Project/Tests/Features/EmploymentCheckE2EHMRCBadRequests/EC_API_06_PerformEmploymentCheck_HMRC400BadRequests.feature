Feature: EmploymentCheckE2EHMRCBadRequests

@api
@regression
@employmentcheckapi
Scenario: EC_API_006_PerformEmploymentCheck_HMRC400BadRequests
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	Then data is enriched with results from DC and Accounts
	And employment check database is updated with the result from HMRC '<Employed>', '<ReturnCode>', '<ReturnMessage>'
	And employment check record status is '<Status>'
	And business outcome for the check is set to '<ErrorType>'

Examples:
	| TestCaseId | MinDate             | MaxDate             | Employed | ReturnCode | ReturnMessage                                                  | Status | ErrorType   |
	| 6          | 2014-03-06T00:00:00 | 2013-03-06T00:00:00 |          | 400        | {"code":"BAD_REQUEST","message":"From date was after to date"} | 2      | HmrcFailure |