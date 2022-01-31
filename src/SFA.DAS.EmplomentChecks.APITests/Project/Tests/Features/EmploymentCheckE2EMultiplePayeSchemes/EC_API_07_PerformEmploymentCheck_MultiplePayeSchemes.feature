Feature: EmploymentCheckE2EMultiplePayeSchemes

@api
@regression
@employmentcheckapi
Scenario: EC_API_07_PerformEmploymentCheck_MultiplePayeSchemes
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	And multiple paye schemes are found on account
	Then an employment check request is created for each unique Nino and paye scheme combination

	Examples:
		| TestCaseId | MinDate             | MaxDate             |
		| 7          | 2014-03-06T00:00:00 | 2013-03-06T00:00:00 |