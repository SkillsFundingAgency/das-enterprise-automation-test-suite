@approvals
Feature: AP_CoC_03

@regression
@cocscenarios
Scenario: AP_CoC_03 Employer requests changes to cost and course Before ILR match and Provider approves
	Given the Employer has approved apprentice
	When the Employer edits cost and course and confirm the changes before ILR match
	Then the provider can review and approve the changes