Feature: StartDateChangeOfCircumstance-Builders
	When the refreshed learner data contains an updated start date
	Then the apprenticeship incentive is updated

Scenario: Clawbacks 1 - Start Date Change Of Circumstance with eligible start date changing learner's age from under to over 25 - paid earning
	Given an existing apprenticeship incentive with learning starting on 12-Nov-2020
	And a payment of £1000 sent in Period R07 2021
	And a start date change of circumstance occurs in Period R08 2021
	And learner data is updated with a new learning start date 13-Dec-2020 making the learner over twenty five at the start of learning
	When the incentive learner data is refreshed
	And the earnings are recalculated
	Then the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08 2021
	And a new first pending payment of £750 is created for Period R08 2021
	And a new second pending payment of £750 is created for Period R05 2122