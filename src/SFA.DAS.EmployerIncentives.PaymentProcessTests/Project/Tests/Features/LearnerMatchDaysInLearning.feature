@employerincentivesPaymentsProcess
Feature: LearnerMatchDaysInLearning
    Learner Match - Learning Day Count

Scenario: 1. Learning Day Count Check - Phase 2
   Given an existing Phase2 apprenticeship incentive
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period

Scenario: 2. Subsequent Learning Day Count Check - Phase 2
   Given an existing Phase2 apprenticeship incentive
   And a successful Learner Match in previous collection period
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period

Scenario: 3. Learning Day Count Check - Phase 1
   Given an existing Phase1 apprenticeship incentive
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period

Scenario: 4. Subsequent Learning Day Count Check - Phase 1
   Given an existing Phase2 apprenticeship incentive
   And a successful Learner Match in previous collection period
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period

Scenario: 5. Learning Day Count Check when Learning Stopped - Phase 2
   Given an existing Phase2 apprenticeship incentive
   And ILR Learner Stopped Change of Circumstance has occurred
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to false
   And the Number of days in learning is calculated and set as ILRStart Date to LearningStoppedDate in the Learner table

Scenario: 6. Learning Day Count Check when Learning Stopped - Phase 1
   Given an existing Phase1 apprenticeship incentive
   And ILR Learner Stopped Change of Circumstance has occurred
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to false
   And the Number of days in learning is calculated and set as ILRStart Date to LearningStoppedDate in the Learner table

Scenario: 7. Learning Day Count Check when Learning Stopped and Resumed - Phase 2
   Given an existing Phase2 apprenticeship incentive
   And ILR Learner Stopped Change of Circumstance has occurred
   And a successful Learner Match in previous collection period
   And ILR Learner Resumed Change of Circumstance has occurred in the current period
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is calculated and set as a total number of days spent in learning

Scenario: 8. Learning Day Count Check when Learning Stopped and Resumed - Phase 1
   Given an existing Phase1 apprenticeship incentive
   And ILR Learner Stopped Change of Circumstance has occurred
   And a successful Learner Match in previous collection period
   And ILR Learner Resumed Change of Circumstance has occurred in the current period
   When the Learner Match occurs
   Then the SubmissionFound Column in Learner table is set to true
   And the LearningFound Column in Learner table is set to true
   And the InLearning Column in Learner table is set to true
   And the Number of days in learning is calculated and set as a total number of days spent in learning
