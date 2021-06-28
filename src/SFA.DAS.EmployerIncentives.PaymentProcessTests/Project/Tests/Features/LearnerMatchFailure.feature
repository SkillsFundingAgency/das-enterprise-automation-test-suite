@employerincentivesPaymentsProcess
Feature: LearnerMatchFailure
    Learner Match Continues on failure
    https://skillsfundingagency.atlassian.net/browse/EI-1208
    Reproduces failure in SFA.DAS.EmployerIncentives.Domain.ApprenticeshipIncentives.ApprenticeshipIncentive.cs
        private void StopBreakInLearning(LearningStoppedStatus status)
        {
            var stopDate = status.DateResumed.Value.AddDays(-1); // here DateResumed is null because learning had resumed with a different Apprenticeship Id
            ...
        }

Scenario: Learner Match Continues on failure
    Given the learner match process has been triggered
    When an exception occurs for a learner
    Then a record of learner match failure is created for the learner
    And the learner match process should continue for all remaining learners
    And any CoCs are processed for each learner (excluding exceptions)
    And days in learning is calculated for each learner (excluding exceptions)