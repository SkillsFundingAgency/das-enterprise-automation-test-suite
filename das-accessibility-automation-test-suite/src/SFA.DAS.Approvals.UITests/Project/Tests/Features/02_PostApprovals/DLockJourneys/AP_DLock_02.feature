Feature: AP_DLock_02

@regression
@liveapprentice
@dlockscenarios
@postapprovals
Scenario: AP_DLock_02 Triaging and resolving mismatch Datalocks after ILR match
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with price mismatch
	And provider requests Employer to update details in MA
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved