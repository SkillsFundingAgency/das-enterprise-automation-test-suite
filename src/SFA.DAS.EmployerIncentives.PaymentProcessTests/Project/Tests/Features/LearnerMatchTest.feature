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
	When the learner is found in learning in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has in learning set to true

Scenario: Learner match found in previous academic year not current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has in learning set to true

Scenario: Learner match found in previous and current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous and current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has in learning set to true

Scenario: Learner match not in learning in previous and in learning in current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found not in learning in the previous academic year
	And the learner is found in learning in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has in learning set to true

Scenario: Learner match not in learning in previous or current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found not in learning in the previous academic year
	And the learner is found not in learning in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has in learning set to false

Scenario: Learner match found with data lock in previous academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous academic year
	And the learner has a data lock for a price episode in the previous academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has data lock set to true

Scenario: Learner match found with data lock in previous academic year and no data lock in current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous academic year
	And the learner has a data lock for a price episode in the previous academic year
	And the learner match service is completed
	And a learner match record is created for the apprenticeship id
	And the learner record has data lock set to true
	And the learner is found in learning in the current academic year
	And the learner has no data lock for a price episode in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has data lock set to false

Scenario: Learner match found with no data lock in previous or current academic years
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous academic year
	And the learner has no data lock for a price episode in the previous academic year
	And the learner match service is completed
	And a learner match record is created for the apprenticeship id
	And the learner record has data lock set to false
	And the learner is found in learning in the current academic year
	And the learner has no data lock for a price episode in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has data lock set to false

Scenario: Learner match found with no data lock in previous academic year and data lock in current academic year
	Given an apprenticeship incentive for a learner submitted in the previous academic year
	When the learner is found in learning in the previous academic year
	And the learner has no data lock for a price episode in the previous academic year
	And the learner match service is completed
	And a learner match record is created for the apprenticeship id
	And the learner record has data lock set to false
	And the learner is found in learning in the current academic year
	And the learner has a data lock for a price episode in the current academic year
	And the learner match service is completed
	Then a learner match record is created for the apprenticeship id
	And the learner record has data lock set to true

Scenario: Submission Not Found during end of year roll over
	Given an incentive application has a learner match record in previous academic year
	When a learner match request in the current academic year does not find the requested ULN and UKPRN
	Then update the learner match record to reflect that no current data has been found

Scenario: Learning found in previous academic year but not in current academic year and provider has NOT submitted ILR in current academic year
	Given an incentive application has a learner match record in previous academic year	
	And the provider has not submitted an ILR in the current academic year
	And learner match has a matching apprenticeship ID in a price episode in the previous academic year
	When the learner match process has run
	Then learner data is updated to reflect that learning has been found

Scenario: Learning found in current academic year but not in previous academic year
	Given an incentive application has a learner match record in previous academic year
	And learner match finds a matching apprenticeship ID in a price episode in the current academic year 
	And learner match does not have a matching apprenticeship ID in a price episode in the previous academic year
	When the learner match process has run
	Then learner data is updated to reflect that learning has been found

Scenario: Learning found in previous academic year but not current academic year AND provider has submitted ILR in current academic year
	Given an incentive application has a learner match record in previous academic year	
	And learner match has a matching apprenticeship ID in a price episode in the previous academic year but not the current academic year
	When the learner match process has run
	Then learner data is updated to reflect that learning has been found
	And the learning is not stopped
