Feature: NonLevyEmployerCreatesACohort

A Non Levy employer creates a cohort using the reservation

@regression
@non-levy
Scenario: Non Levy Employer creates a cohort using the reservation
	Given the Employer has created a new reservation to add an apprentice
	When the Employer uses the reservation to create and approve 1 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts