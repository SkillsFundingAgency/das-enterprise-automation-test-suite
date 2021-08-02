@employerincentivesPaymentsProcess
Feature: AcademicYearRollover
https://skillsfundingagency.atlassian.net/browse/EI-1317
RO&MAYs - revisit Learning stopped trigger for multiple academic years

Scenario: AC3 - do not trigger learning stopped after end of previous Academic Year
	Given an existing Phase1 apprenticeship incentive
	And the end date of the most recent price episode is the census date of the previous Academic Year 
	When a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year
	And the provider has not submitted an ILR for the current Academic
	Then do not trigger a learning stopped CoC event