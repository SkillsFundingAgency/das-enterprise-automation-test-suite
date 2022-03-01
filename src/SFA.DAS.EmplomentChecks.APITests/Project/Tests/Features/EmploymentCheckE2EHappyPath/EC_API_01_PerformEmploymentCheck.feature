Feature: EmploymentCheckE2EHappyPath

@api
@regression
@employmentcheckapi
Scenario: EC_API_001_PerformEmploymentCheck_HappyPath
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	And employment check record status is '<Status1>'
	When apprentice employment check is triggered
	Then data is enriched with results from DC and Accounts
	And employment check database is updated with the result from HMRC '<Employed>', '<ReturnCode>', '<ReturnMessage>'
	And employment check record status is '<Status2>' 

	Examples:
		| TestCaseId | MinDate             | MaxDate             | Status1 | Employed | ReturnCode | ReturnMessage | Status2 |
		| 1          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | 1       | true     | 200        | OK            | 2       |
		| 2          | 2016-05-01T00:00:00 | 2016-11-01T00:00:00 | 1       | false    | 200        | OK            | 2       |