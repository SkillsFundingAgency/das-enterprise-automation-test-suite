Feature: EmploymentCheckE2EPayeIsNull

@api
@regression
@employmentcheckapi
Scenario: EC_API_03_PerformEmploymentCheck_PayeIsNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Paye/Scheme is not found
	Then do not create an Employment Check request

	Examples:
		| TestCaseId | MinDate             | MaxDate             | Employed | ReturnCode | ReturnMessage      |
		| 4          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 |          | null       | PayeScheme is null |