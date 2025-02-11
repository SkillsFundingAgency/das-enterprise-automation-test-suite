Feature: EmploymentCheckE2EContinueWhenLearnerNotFoundOnPaye

@api
@regression
@employmentcheckapi
Scenario: EC_API_009_PerformEmploymentCheck_ContinueWhenLearnerNotFound
	Given employment check has been requested for an apprentice with '<TestCaseId>', '<MinDate>', '<MaxDate>'
	When multiple paye schemes are found on account
	And an employment check request is created for each unique Nino and paye scheme combination
	And Learner is found to be '<Employed>' on one of the paye schemes
	Then continue with the remaining paye schemes for the check

Examples:
	| TestCaseId | MinDate             | MaxDate             | Employed |
	| 9          | 2020-03-06T00:00:00 | 2021-03-06T00:00:00 | false    |