Feature: EmploymentCheckE2EStopWhenLearnerFoundOnPaye

@api
@regression
@employmentcheckapi
Scenario: EC_API_008_PerformEmploymentCheck_StopWhenLearnerFound
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	And employment check record status is '<Status1>'
	When multiple paye schemes are found on account
	And an employment check request is created for each unique Nino and paye scheme combination
	And Learner is found to be '<Employed>' on one of the paye schemes
	Then abandon all the remaining paye schemes for the check
	And employment check record status is '<Status2>' 

Examples:
	| TestCaseId | MinDate             | MaxDate             | Status1 | Employed | Status2 |
	| 8          | 2014-03-06T00:00:00 | 2015-03-06T00:00:00 | 1       | true     | 2       |
