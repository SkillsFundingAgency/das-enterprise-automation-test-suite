@employerincentivesPaymentsProcess
@academicYearRollover
Feature: AcademicYearRollover
https://skillsfundingagency.atlassian.net/browse/EI-1317
RO&MAYs - revisit Learning stopped trigger for multiple academic years

Scenario: 1 - trigger learning stopped for current Academic Year
	Given an existing Phase1 apprenticeship incentive
	And the end date of the most recent price episode is before the census date of the active collection period
	When a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year
	Then trigger a Learning stopped CoC event

Scenario: 2 - trigger learning stopped for previous Academic Year
	Given an existing Phase1 apprenticeship incentive
	And the end date of the most recent price episode is before the census date of the previous Academic Year 
	When a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year
	Then trigger a Learning stopped CoC event

Scenario: 3 - do not trigger learning stopped after end of previous Academic Year
	Given an existing Phase1 apprenticeship incentive
	And the end date of the most recent price episode is the census date of the previous Academic Year 
	When a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year
	Then do not trigger a learning stopped CoC event

# https://skillsfundingagency.atlassian.net/browse/EI-1403
Scenario: 4- Learning stops in R1 after learner has been added for R13
	Given an existing Phase1 apprenticeship incentive
	And the end date of the most recent price episode is the census date of the previous Academic Year 
	When in period R01 of the new academic year the most recent price episode has no periods
	And a call to the learner match service is made for an incentive application after the census date for R12 of the previous academic year
	Then trigger a Learning stopped CoC event
