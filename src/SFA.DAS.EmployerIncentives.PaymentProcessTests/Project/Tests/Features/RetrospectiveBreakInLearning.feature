@employerincentivesPaymentsProcess
Feature: RetrospectiveBreakInLearning

Scenario: Simple Retro BIL - Learner Stopped before First Payment due date and Resumed later
	Given an existing apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
	And a payment of £1000 is not sent in Period R07 2021
	And Learner data is updated with a Break in Learning of 28 days before the first payment due date
	When the Learner Match is run in Period R02 2122
	And the earnings are recalculated
	Then the Break in Learning is recorded
	And a new first pending payment of £1000 is created for Period R08 2021
	And a new second pending payment of £1000 is created for Period R05 2122
	And the Learner is In Learning