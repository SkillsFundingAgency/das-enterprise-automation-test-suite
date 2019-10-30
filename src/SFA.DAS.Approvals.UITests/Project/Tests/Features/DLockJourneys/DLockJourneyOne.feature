@approvals
Feature: DLockJourneyOne

@regression
@liveapprentice
@dlockscenarios
Scenario: DLOCK1 Triaging and resolving mismatch Datalocks before ILR match
	Given the Employer has approved apprentice
	When the provider submit an ILR with price mismatch
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved