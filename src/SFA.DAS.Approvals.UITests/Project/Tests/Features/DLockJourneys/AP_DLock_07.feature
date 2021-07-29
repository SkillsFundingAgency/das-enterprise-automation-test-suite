@approvals
Feature: AP_DLock_07
	

@regression
@liveapprentice
@dlockscenarios
Scenario: AP_DLock_07 Triaging and resolving mismatch Datalocks after ILR match - multiple ilr links in the banner
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with price mismatch
	And the provider submit another ILR with course mismatch
	Then provider will see two links on PAS for each ILR mismatch