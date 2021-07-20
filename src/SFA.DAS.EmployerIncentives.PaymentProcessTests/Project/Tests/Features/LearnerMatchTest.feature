Feature: LearnerMatchTest
	Test feature to verify learner match helper is working

@employerincentivesPaymentsProcess
Scenario: Learner match runs
	Given there are some apprenticeship incentives
	When the learner match service is completed
	Then a learner match record is created for the apprenticeship id

Scenario: Learner match not found
	Given an apprenticeship incentive for a learner
	When the learner is not found
	And the learner match service is completed
	Then a learner match record is not created for the apprenticeship id

Scenario: Learner match found in current academic year not previous academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id

Scenario: Learner match found in previous academic year not current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in the previous academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id

Scenario: Learner match found in previous and current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in the previous and current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id

