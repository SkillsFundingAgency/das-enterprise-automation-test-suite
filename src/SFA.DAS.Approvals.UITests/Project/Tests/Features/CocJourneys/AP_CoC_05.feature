@approvals
Feature: AP_CoC_05

@regression
@liveapprentice
@cocscenarios
Scenario: AP_CoC_05 Employer or Provider cannot make change to cost and course after ILR match on live Apprentice
	Given the Employer has approved apprentice
	Then Employer cannot make changes to cost and course after ILR match
	And provider cannot make changes to cost and course after ILR match