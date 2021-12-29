Feature: EmploymentCheckE2E

@api
@regression
@employmentcheck
Scenario: EC_API_01_PerformEmploymentCheck
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	Then data is enriched with results from DC and Accounts
	And employment check database is updated with the result from HMRC '<Employed>', '<ReturnCode>', '<ReturnMessage>'

	Examples:
		| TestCaseId | MinDate             | MaxDate             | Employed | ReturnCode | ReturnMessage                   |
		| 1          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | true     | 200 (OK)   |                                 |
		| 2          | 2016-05-01T00:00:00 | 2016-11-01T00:00:00 | false    | 200 (OK)   |                                 |
		| 3          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 |          | null       | NationalInsuranceNumber is null |