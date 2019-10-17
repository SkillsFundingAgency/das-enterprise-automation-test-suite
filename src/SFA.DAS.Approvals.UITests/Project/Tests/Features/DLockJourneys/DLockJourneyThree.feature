Feature: DLockJourneyThree

@regression
@liveapprentice
@dlockscenarios
Scenario: DLOCK3 Employer can stop the live apprentice after Datalocks and ILR match
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with course price mismatch
	Then the Employer can stop the live apprentice
	And the ILR should be matched and datalock is resolved