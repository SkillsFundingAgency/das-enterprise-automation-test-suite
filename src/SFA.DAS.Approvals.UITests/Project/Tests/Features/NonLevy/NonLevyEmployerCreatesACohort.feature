@approvals
Feature: NonLevyEmployerCreatesACohort

A Non Levy employer creates a cohort using the reservation

@regression
@non-levy
@ignore
Scenario: Non Levy Employer creates a cohort using the reservation
	Given the Employer login using existing eoi account
	When the Employer uses the reservation to create and approve 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts