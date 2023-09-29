Feature: AP_DLock_01

@regression
@liveapprentice
@dlockscenarios
@postapprovals
Scenario: AP_DLock_01 Triaging and resolving mismatch Datalocks before ILR match
	Given the Employer has approved apprentice
	When the provider submit an ILR with price mismatch
	And provider requests Employer to update details in MA
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved