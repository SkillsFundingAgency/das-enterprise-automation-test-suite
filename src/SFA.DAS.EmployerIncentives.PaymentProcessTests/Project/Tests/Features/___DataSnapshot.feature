Feature: ___DataSnapshot
	Simple calculator for adding two numbers

Scenario: Save data snapshot
	Given data exists
	When saving a snapshot
	Then it is saved to a file