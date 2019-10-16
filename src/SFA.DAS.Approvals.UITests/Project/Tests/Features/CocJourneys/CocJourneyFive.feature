Feature: CocJourneyFive

@regression
@liveapprentice
@cocscenarios
Scenario: COC5 Employer or Provider cannot make change to cost and course after ILR match on live Apprentice
	Given the Employer has approved apprentice
	Then Employer cannot make changes to cost and course after ILR match
	And provider cannot make changes to cost and course after ILR match