@employerincentivesPaymentsProcess
@learnerMatchLearningResumed
@eiRegression
@learnerMatchTests
Feature: LearnerMatchLearningResumed
	Learning resumed trigger for multiple academic years

Scenario: 1. Learning Stopped and Resumed - Phase 2
   Given an existing Phase2 apprenticeship incentive submitted in Academic Year 2021
   And ILR Learner Stopped Change of Circumstance has occurred
   And a successful Learner Match in previous collection period
   And ILR Learner Resumed Change of Circumstance has occurred in the current period
   When the Learner Match occurs in Period R01 2122
   Then earnings are re-calculated
   And a Learning Resumed change of circumstance is recorded

Scenario: 2. Learning Stopped and Resumed - Phase 1
   Given an existing Phase1 apprenticeship incentive submitted in Academic Year 2021
   And ILR Learner Stopped Change of Circumstance has occurred
   And a successful Learner Match in previous collection period
   And ILR Learner Resumed Change of Circumstance has occurred in the current period
   When the Learner Match occurs in Period R04 2021
   Then earnings are re-calculated
   And a Learning Resumed change of circumstance is recorded
