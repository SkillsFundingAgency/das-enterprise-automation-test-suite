@employerincentivesPaymentsProcess
Feature: LearnerMatchFailure
    Learner Match Continues on failure


Scenario: Learner Match Continues on failure
    Given the learner match process has been triggered
    When an exception occurs for a learner
    Then each exception is logged with the detail of the exception in Kabana and Apps Insight
    And the learner match process should continue for all remaining learners
    And any CoCs are processed for each learner (excluding exceptions)
    And days in learning is calculated for each learner (excluding exceptions)