@employerincentivesPaymentsProcess
Feature: StartDateChangeOfCircumstance
	When the refreshed learner data contains an updated start date
	Then the apprenticeship incentive is updated

Scenario: Clawbacks 1 - Start Date Change Of Circumstance with eligible start date changing learner's age from under to over 25 - paid earning
	Given an existing apprenticeship incentive with learning starting on 12-Nov-2020 and ending on 15-Oct-2022
	And a payment of £1000 sent in Period R07 2021
	And a start date change of circumstance occurs in Period R08 2021
	And learner data is updated with a new learning start date 13-Dec-2020 making the learner over twenty five at the start of learning
	When the incentive learner data is refreshed
	And the earnings are recalculated
	Then the paid earning of £1000 is marked as requiring a clawback in the currently active Period R08 2021
	And a new first pending payment of £750 is created for Period R08 2021
	And a new second pending payment of £750 is created for Period R05 2122

Scenario: Phase2 1 - Learner Applied for Phase2 Incentives Payments- Age changes with the Start date COC( DOB 15-04-1996 -   Initial start date 01-04-2021 - COC - 31-May-2021 )
    Given an existing phase 2 apprenticeship incentive for a learner under 25 years old
    When the start date is changed making the learner 25 on the start date
	And the earnings are recalculated
    Then a new first pending payment of £1500 is created
	And a new second pending payment of £1500 is created

Scenario: Phase2 2 - Learner Applied for Phase2 Incentives Payments with ineligible start date ( COC - 31-Mar-2021)
    Given an existing phase 2 apprenticeship incentive
    When the start date is changed to before the start of the eligibility period in period 8 AY 2021
	And the earnings are recalculated
    Then the first earning is removed
    And the second earning is removed

Scenario: Data submitted for previous academic year in R13 - eligible start date
	Given an existing phase 2 apprenticeship incentive
	And a start date change of circumstance occurs in Period R13 2021
	When the start date is changed to a date after the start of the eligibility period in period 13 AY 2021
	And the earnings are recalculated
    Then a new first pending payment of £1500 is created for Period R11 2021
	And a new second pending payment of £1500 is created for Period R08 2122

Scenario: Data submitted for previous academic year in R14 - eligible start date
	Given an existing phase 2 apprenticeship incentive
	And a start date change of circumstance occurs in Period R14 2021
	When the start date is changed to a date after the start of the eligibility period in period 14 AY 2021
	And the earnings are recalculated
    Then a new first pending payment of £1500 is created for Period R11 2021
	And a new second pending payment of £1500 is created for Period R08 2122

Scenario: Data submitted for previous academic year in R13 - ineligible start date
	Given an existing phase 2 apprenticeship incentive
    When the start date is changed to before the start of the eligibility period in period 13 AY 2021
	And the earnings are recalculated
    Then the first earning is removed
    And the second earning is removed

Scenario: Data submitted for previous academic year in R14 - ineligible start date
	Given an existing phase 2 apprenticeship incentive
    When the start date is changed to before the start of the eligibility period in period 14 AY 2021
	And the earnings are recalculated
    Then the first earning is removed
    And the second earning is removed

Scenario: Start date change for previous academic year submitted for current academic year
	Given an existing phase 2 apprenticeship incentive
	And a start date change of circumstance occurs in Period R01 2122
	When the start date is changed to a date after the start of the eligibility period in period 12 AY 2021
	And the earnings are recalculated
    Then a new first pending payment of £1500 is created for Period R11 2021
	And a new second pending payment of £1500 is created for Period R08 2122
