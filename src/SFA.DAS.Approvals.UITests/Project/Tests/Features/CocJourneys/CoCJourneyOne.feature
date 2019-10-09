Feature: CoCJourneyOne

@regression
@cocscenarios
Scenario: Employer requests change to dob and reference After ILR match and Provider approves
	Given the Employer has approved apprentice
	When the Employer edits Dob and Reference and confirm the changes after ILR match
	Then the provider can review and approve the changes