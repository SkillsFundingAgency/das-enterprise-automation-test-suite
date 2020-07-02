@approvals
Feature: AP_CoC_06

@regression
@waitingtostartapprentice
@selectstandardcourse
@cocscenarios
Scenario: AP_CoC_06 Employer requests changes to cost and course After ILR match on waiting to start Apprentice and Provider approves
	Given the Employer has approved apprentice
	When the Employer edits cost and course and confirm the changes after ILR match
	Then the provider can review and approve the changes