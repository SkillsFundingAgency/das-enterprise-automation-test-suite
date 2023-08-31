Feature: AP_CoC_07

@regression
@waitingtostartapprentice
@cocscenarios
@postapprovals
Scenario: AP_CoC_07 Provider requests changes to cost and course After ILR match on waiting to start Apprentice and Employer approves
	Given the Employer has approved apprentice
	When the provider edits cost and course and confirm the changes after ILR match
	Then the employer can review and approve the changes