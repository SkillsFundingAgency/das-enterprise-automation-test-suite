@approvals
Feature: DLockJourneyTwo

@regression
@liveapprentice
@dlockscenarios
Scenario: DLOCK2 Triaging and resolving mismatch Datalocks after ILR match
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with price mismatch
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved