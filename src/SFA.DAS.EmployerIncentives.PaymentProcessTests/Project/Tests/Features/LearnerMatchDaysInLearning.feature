@employerincentivesPaymentsProcess
Feature: LearnerMatchDaysInLearning
    Learner Match - Learning Day Count

Scenario: 1. Learning Day Count Check ( Start Date 05-05-2021 Run the Leaner Match for 2021 Period 12)
   Given an existing apprenticeship incentive
   When the Learner Match occurs
   Then Submission Found is set against the Learner
   And Learning Found is set against the Learner
   And In Learning is set against the Learner
   And the Number of days in learning is calculated and set as number of days from ILRStart Date to Census date of the Active Period

   
Scenario: 2. Subsequent Learning Day Count Check ( Start Date 05-05-2021 Run the Leaner Match for 2021 Period 12 and then again in 2122 Period 1)
   Given an existing apprenticeship incentive
   And a successful Learner Match in previous collection period
   When the Learner Match occurs
   Then Submission Found is set against the Learner
   And Learning Found is set against the Learner
   And In Learning is set against the Learner
   And the Number of days in learning is re-calculated and set as number of days from ILRStart Date to Census date of the Active Period
