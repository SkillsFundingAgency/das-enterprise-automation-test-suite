@approvals
Feature: AP_DLock_04

@regression
@liveapprentice
@dlockscenarios
Scenario: AP_DLock_04 Triaging and resolving mismatch Datalocks before ILR match
	Given the Employer has approved apprentice
	When the provider submit an ILR with course mismatch
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved