@employerincentivesPaymentsProcess
Feature: EmploymentCheck

Scenario: New Employment Check - First Submission - Phase 1
	Given an apprenticeship incentive has been submitted in phase 1
	When we have not previously requested an employment check for the learner
	And an ILR submission is received for that learner
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 1 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - First Submission - Phase 2
	Given an apprenticeship incentive has been submitted in phase 2
	When an ILR submission is received for that learner
	And we have not previously requested an employment check for the learner
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - First Submission - Phase 3
	Given an apprenticeship incentive has been submitted in phase 3
	When an ILR submission is received for that learner
	And we have not previously requested an employment check for the learner
	And 6 weeks has elapsed since the start date of the apprenticeship
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 3 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - First Submission - 6 weeks not elapsed
	Given an apprenticeship incentive has been submitted less than 6 weeks ago
	When an ILR submission is received for that learner
	And we have not previously requested an employment check for the learner
	And the learner match is run
	Then a new employment check is not requested

Scenario: New Employment Check - First Submission and Start Date CoC
	Given an apprenticeship incentive has been submitted in phase 2
	When an ILR submission is received for that learner
	And a Start Date Change of Circumstance has been identified in that ILR submission
	And we have not previously requested an employment check for the learner
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - Start Date CoC - Phase 1
	Given an apprenticeship incentive has been submitted in phase 1
	When an ILR submission is received for that learner
	And a Start Date Change of Circumstance has been identified in that ILR submission
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 1 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - Start Date CoC - Phase 2
	Given an apprenticeship incentive has been submitted in phase 2
	When an ILR submission is received for that learner
	And a Start Date Change of Circumstance has been identified in that ILR submission
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - Start Date CoC - Phase 3
	Given an apprenticeship incentive has been submitted in phase 3
	When an ILR submission is received for that learner
	And a Start Date Change of Circumstance has been identified in that ILR submission
	And 6 weeks has elapsed since the start date of the apprenticeship
	And the learner match is run
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 3 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New Employment Check - Start Date CoC - 6 weeks not elapsed
	Given an apprenticeship incentive has been submitted less than 6 weeks ago
	When an ILR submission is received for that learner
	And a Start Date Change of Circumstance has been identified in that ILR submission
	And the learner match is run
	Then a new employment check is not requested

Scenario: Employment check result stored
	Given an employment check has been requested
	And the employment check request has not been superseded
	And we have not previously received a result from the Employment Check service
	When the check has been completed by the Employment Check service
	Then the result is stored

Scenario: Employment check result updated
	Given an employment check has been requested
	And the employment check request has not been superseded
	And we have previously received a result from the Employment Check service
	When the check has been completed by the Employment Check service
	Then the result is updated

Scenario: Employment check superseded
	Given an employment check has been requested
	And the employment check has been superseded
	When the check has been completed by the Employment Check service
	Then the result is discarded

Scenario: Payment validation - Employment check has not been completed
	Given an employment check has been requested
	And the employment check has not returned a result
	And a payment is due for the apprenticeship
	When the month end process is initiated
	Then a payment is not created for the apprenticeship incentive

Scenario: Payment validation - Apprentice was employment prior to scheme phase
	Given an employment check has been requested
	And the employment check returns that the apprentice was employed in the 6 months prior to the scheme phase starting
	And a payment is due for the apprenticeship
	When the month end process is initiated
	Then a payment is not created for the apprenticeship incentive

Scenario: Payment validation - Apprentice was not employment at apprenticeship start
	Given an employment check has been requested
	And the employment check returns that the apprentice was not employed in the 6 weeks after their start date
	And a payment is due for the apprenticeship
	When the month end process is initiated
	Then a payment is not created for the apprenticeship incentive

Scenario: Payment validation - Apprentice eligible for payment
	Given an employment check has been requested
	And the employment check returns that the apprentice was employed in the 6 weeks after their start date
	And the employment check returns that the apprentice was not employed in the 6 months prior to the scheme starting
	And a payment is due for the apprenticeship
	When the month end process is initiated
	And there are no other validation failures
	Then a payment is created for the apprenticeship incentive

Scenario: Payment validation - ILR not submitted
	Given an apprenticeship incentive has been submitted in phase 2
	And an ILR has not been submitted for the learner
	And a payment is due for the apprenticeship
	When the month end process is initiated
	Then a payment is not created for the apprenticeship incentive

Scenario: New check requested by support user
	Given an employment check has failed for an apprenticeship incentive
	And the employer has requested the check be re-ran
	And month end is not in progress
	When the second line support user requests a recheck
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New checks requested
	Given an apprenticeship incentive has been submitted in phase 2
	And an ILR submission has been received for that learner
	And month end is not in progress
	When the refresh of all employment checks is requested
	Then a new employment check is requested to ensure the apprentice was not employed in the 6 months prior to phase 2 starting
	And a new employment check is requested to ensure the apprentice was employed in the six weeks following their start date

Scenario: New checks requested - ILR not submitted
	Given an apprenticeship incentive has been submitted in phase 2
	And an ILR has not been submitted for the learner
	And month end is not in progress
	When the refresh of all employment checks is requested
	Then a new employment check is not requested

Scenario: New checks requested - 6 weeks not elapsed
	Given an apprenticeship incentive has been submitted less than 6 weeks ago
	And month end is not in progress
	When the refresh of all employment checks is requested
	Then a new employment check is not requested

Scenario: New checks requested - incentive withdrawn
	Given an apprenticeship incentive has been submitted in phase 2
	And the apprenticeship incentive has been withdrawn
	And month end is not in progress
	When the refresh of all employment checks is requested
	Then a new employment check is not requested

Scenario: New checks requested - month end in progress
	Given an apprenticeship incentive has been submitted in phase 1
	And an ILR submission has been received for that learner
	And month end is in progress
	When the refresh of all employment checks is requested
	Then a new employment check is not requested