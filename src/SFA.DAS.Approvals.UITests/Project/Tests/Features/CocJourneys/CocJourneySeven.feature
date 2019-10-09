Feature: CocJourneySeven

@regression
@waitingtostartapprentice
@cocscenarios
Scenario: Provider requests changes to cost and course After ILR match on waiting to start Apprentice and Employer approves
	Given the Employer has approved apprentice
	When the provider edits cost and course and confirm the changes after ILR match
	Then the Employer can review and approve the changes