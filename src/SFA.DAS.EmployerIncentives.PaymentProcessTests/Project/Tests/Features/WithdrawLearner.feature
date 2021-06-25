Feature: WithdrawLearner
	Learner Withdrawn

Scenario: Withdraw 1 - Learner Withdrawn triggered  after the Payment of the First Earning has been Clawedback 
Given an existing apprenticeship incentive
And the first payment has been made
And a start date change of circumstance occurs which is eligible for the application phase and results in a different due period
And the learner match process is run
And the paid first earning, payment record and the validation records are retained
And the paid first earning is clawed back for the same amount
And the second unpaid earning is archived then deleted
And new earnings are calculated
When the Learner Withdraw Request is processed
Then the first earnings should have been removed
Then the second earnings should have been removed