Feature: EmploymentCheckE2ENinoAndPayeAreNull

@api
@regression
@employmentcheck
Scenario: EC_API_04_PerformEmploymentCheck_NinoAndPayeAreNull
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	Then data is enriched with results from DC and Accounts
	And employment check database is updated with the result from HMRC '<Employed>', '<ReturnCode>', '<ReturnMessage>'

	Examples:
		| TestCaseId | MinDate             | MaxDate             | Employed | ReturnCode | ReturnMessage                                       |
		| 5          | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 |          | null       | NationalInsuranceNumber is null\|PayeScheme is null |