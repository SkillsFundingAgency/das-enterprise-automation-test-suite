Feature: RollOverAndYearEnd
	Tests to verify rolling over a year end does not affect the month end processing

@employerincentivesPaymentsProcess
Scenario: Submission Not Found
	Given an incentive application has a learner match record in previous academic year
	When a learner match request in the current academic year does not find the requested ULN and UKPRN
	Then update the learner match record to reflect that no current data has been found