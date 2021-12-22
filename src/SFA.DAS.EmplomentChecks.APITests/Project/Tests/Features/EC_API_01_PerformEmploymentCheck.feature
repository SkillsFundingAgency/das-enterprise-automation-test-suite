Feature: EmploymentCheckE2E

@api
@regression
@employmentcheck
Scenario: EC_API_01_PerformEmploymentCheck
	
	Given employment check has been requested for an apprentice with '<ULN>', '<AccountId>', '<MinDate>', '<MaxDate>'
	When apprentice employment check is triggered
	Then data is enriched with results from DC and Accounts
	And HMRC check is performed for the apprentice
	And employment check database is updated with the result '<Employed>'

	Examples:
	
		| ULN        | AccountId | MinDate             | MaxDate             | Employed |
		| 9000000601 | 1997      | 2014-03-06T00:00:00 | 2014-03-06T00:00:00 | true     |