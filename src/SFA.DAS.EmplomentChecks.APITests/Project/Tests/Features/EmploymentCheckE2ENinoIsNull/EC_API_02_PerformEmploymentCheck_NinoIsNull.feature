Feature: EmploymentCheckE2ENinoIsNull

@api
@regression
@employmentcheck
Scenario: EC_API_02_PerformEmploymentCheck_NinoIsNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And data is enriched with results from DC and Accounts
	And Nino is not found
	Then do not create an Employment Check request

	Examples:
		| TestCaseId | MinDate             | MaxDate             | Employed | ReturnCode | ReturnMessage                   |
		| 3          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 |          | null       | NationalInsuranceNumber is null |