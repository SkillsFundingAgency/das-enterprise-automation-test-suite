@employerincentivesPaymentsProcess
@learnerMatchFailure
@learnerMatchTests

@ignore

Feature: LearnerMatchFailure
    Learner Match Continues on failure
    https://skillsfundingagency.atlassian.net/browse/EI-1208

Scenario: Learner Match Continues on failure
    Given the learner match process has been triggered
    When an exception occurs for a learner
    Then a record of learner match failure is created for the learner
    And the learner match process should continue for all remaining learners