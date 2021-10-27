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

Scenario: Simple Retro BIL 2 - Break in Learning less than 28 days
    Given an existing Phase1 apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
    And a payment of £1000 is not sent in Period R07 2021
    And Learner data is updated with a Break in Learning of less than 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then no Break in Learning is recorded
    And the pending payments are not changed

Scenario: Simple Retro BIL 3 - Learner Stopped before First Payment due date and Resumed later for Phase2
    Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
    And a payment of £1500 is not sent in Period R12 2021
    And Learner data is updated with a Break in Learning of 28 days before the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new first pending payment of £1500 is created for Period R01 2122
    And a new second pending payment of £1500 is created for Period R10 2122

Scenario: Simple Retro BIL 4 - Learner Stopped After First Payment Paid and Before Second Payment due and Resumed later
    Given an existing Phase1 apprenticeship incentive with learning starting on 30-Nov-2020 and ending on 31-Jul-2021
    And a payment of £1000 is sent in Period R07 2021
    And Learner data is updated with a Break in Learning of 28 days after the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new second pending payment of £1000 is created for Period R05 2122

Scenario: Simple Retro BIL 5 - Learner Stopped After First Payment due date and Resumed later for Phase2
    Given an existing Phase2 apprenticeship incentive with learning starting on 30-Apr-2021 and ending on 31-Jul-2022
    And a payment of £1500 is sent in Period R12 2021
    And Learner data is updated with a Break in Learning of 28 days after the first payment due date
    When the Learner Match is run in Period R02 2122
    And the earnings are recalculated
    Then the Break in Learning is recorded
    And a new second pending payment of £1500 is created for Period R10 2122

