Feature: StartDateChangeOfCircumstance
	When the refreshed learner data contains an updated start date
	Then the apprenticeship incentive is updated

Scenario: Clawbacks 1 - Start Date Change Of Circumstance with eligible start date changing learner's age from under to over 25 - paid earning
	Given an existing apprenticeship incentive
	And a payment of £1000 sent in Period R07
	And a start date change of circumstance occurs in Period R08
	And learner data is updated with a new valid start date making the learner over twenty five at the start of learning
	When the incentive learner data is refreshed
	And the earnings are recalculated
	Then the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08
	And a new first pending payment of £750 is created
	And a new second pending payment of £750 is created