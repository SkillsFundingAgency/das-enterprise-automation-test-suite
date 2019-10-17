Feature: CoCJourneyTwo

@regression
@cocscenarios
Scenario: COC2 Provider requests change to dob and reference After ILR match and Employer approves
	Given the Employer has approved apprentice
	When the provider edits Dob and Reference and confirm the changes after ILR match
	Then the Employer can review and approve the changes