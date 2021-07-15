Feature: LearnerMatchTest
	Test feature to verify learner match helper is working

@employerincentivesPaymentsProcess
Scenario: Learner match runs
	Given there are some apprenticeship incentives
	When the learner match service is completed
	Then we have some learner data

Scenario: Learner match not found
	Given an apprenticeship incentive for a learner
	When the learner match service is completed
	And the learner is not found
	Then a learner match record is not created

