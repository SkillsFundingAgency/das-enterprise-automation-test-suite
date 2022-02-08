Feature: EmploymentCheckE2EStopWhenLearnerFoundOnPaye

@api
@regression
@employmentcheckapi
Scenario: EC_API_08_PerformEmploymentCheck_StopWhenLearnerFound
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When multiple paye schemes are found on account
	And an employment check request is created for each unique Nino and paye scheme combination
	And Learner is found to be '<Employed>' on one of the paye schemes
	Then abandon all the remaining paye schemes for the check

Examples:
	| TestCaseId | MinDate             | MaxDate             | Employed |
	| 8          | 2014-03-06T00:00:00 | 2015-03-06T00:00:00 | true     |
