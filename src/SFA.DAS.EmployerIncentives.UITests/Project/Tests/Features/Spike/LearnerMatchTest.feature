Feature: LearnerMatchTest
	Test feature to verify learner match helper is working

@employerincentivesSpike
Scenario: Learner match runs
	Given there are some apprenticeship incentives
	When the learner match service is completed
	Then we have some learner data