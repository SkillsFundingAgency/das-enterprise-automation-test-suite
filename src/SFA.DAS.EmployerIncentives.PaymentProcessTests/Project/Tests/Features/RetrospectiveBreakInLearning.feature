@employerincentivesPaymentsProcess
Feature: RetrospectiveBreakInLearning

Scenario: Simple Retro BIL 1 - Learner Stopped before First Payment due date and Resumed later
    Given an existing Phase1 apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
    And a payment of £1000 is not sent in Period R07 2021
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new first pending payment of £1000 is created for Period R08 2021
    And a new second pending payment of £1000 is created for Period R05 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 2 - Break in Learning less than 28 days
    Given an existing Phase1 apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
    And a payment of £1000 is not sent in Period R07 2021
    And Learner data is updated with a Break in Learning of less than 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new first pending payment of £1000 is created for Period R08 2021
    And a new second pending payment of £1000 is created for Period R05 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 3 - Learner Stopped before First Payment due date and Resumed later for Phase2
    Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
    And a payment of £1500 is not sent in Period R12 2021
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new first pending payment of £1500 is created for Period R01 2122
    And a new second pending payment of £1500 is created for Period R10 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 4 - Learner Stopped After First Payment Paid and Before Second Payment due and Resumed later
    Given an existing Phase1 apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
    And a payment of £1000 is sent in Period R07 2021
    And Learner data is updated with a Break in Learning of 28 days after the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new second pending payment of £1000 is created for Period R05 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 5 - Learner Stopped After First Payment due date and Resumed later for Phase2
    Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
    And a payment of £1500 is sent in Period R12 2021
    And Learner data is updated with a Break in Learning of 28 days after the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new second pending payment of £1500 is created for Period R10 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 6 - Learner Stopped Before First Payment due date after First Payment paid and Resumed later for Phase2  (BIL start date is 27-07-2021 end date is 24-08-2021)
	Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
	And a payment of £1500 is sent in Period R12 2021
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date starting 27-July-2021     
	When the Learner Match is run in Period R02 2122
	And the earnings are recalculated
	Then the Break in Learning is recorded
    And the paid earning of £1500 is marked as requiring a clawback in Period R02 2122
    And a new first pending payment of £1500 is created for Period R01 2122
	And a new second pending payment of £1500 is created for Period R10 2122
    And the Learner is In Learning

Scenario: Simple Retro BIL 7 - Learner Stopped before First Payment due date when due date within delay period
    Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022 submitted on 07-Aug-2021
    And a payment of £1500 is not sent in Period R01 2122
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And the first payment is still in Period R01 2122

Scenario: Multiple Retro BIL - Learner Stopped before First Payment due date and Resumed later several time for Phase2
	Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
	And a payment of £1500 is not sent in Period R12 2021
	And Learner data is updated with a Break in Learning of 28 days before the first payment due date
    And Learner data is updated with a Break in Learning of 28 days starting 1 month after the first break resume
    When the Learner Match is run in Period R11 2122
	And the earnings are recalculated
	Then the Break in Learning is recorded
	And a new first pending payment of £1500 is created for Period R01 2122
	And a new second pending payment of £1500 is created for Period R11 2122
    And the Learner is In Learning

Scenario: Amend Retro BIL - Learner Stopped before First Payment due date and Resumed later and Amended for Phase2
    Given an existing Phase2 apprenticeship incentive with learning starting on 31-Aug-2021 and ending on 31-Jul-2023
    And a payment of £1500 is not sent in Period R04 2122
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
	And the Learner Match is run in Period R06 2122
	And the Payment Run occurs
    And a payment of £1500 is sent in Period R06 2122
	And Learner data is updated with a Break in Learning of 56 days after the first payment due date
	When the Learner Match is run in Period R07 2122
    And the earnings are recalculated
    Then the Break in Learning is amended
	And a new second pending payment of £1500 is created for Period R03 2223
	And the Learner is In Learning
	
Scenario:Remove Retro BIL - Learner Stopped before First Payment due date and Resumed later and Removed for Phase2
	Given an existing Phase2 apprenticeship incentive with learning starting on 31-Aug-2021 and ending on 31-Jul-2023
    And a payment of £1500 is not sent in Period R04 2122
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
	And the Learner Match is run in Period R06 2122
	And the Payment Run occurs
	And a payment of £1500 is sent in Period R06 2122
	And Learner data is updated with learning starting on 30-Nov-2021 and ending on 31-Jul-2023
	When the Learner Match is run in Period R07 2122
    And the earnings are recalculated
    Then the Break in Learning is Removed
	And the paid earning of £1500 is marked as requiring a clawback in Period R07 2122
	And a new first pending payment of £1500 is created for Period R07 2122
	And a new second pending payment of £1500 is created for Period R04 2223
	And the Learner is In Learning