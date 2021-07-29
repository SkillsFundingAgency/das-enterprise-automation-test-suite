@approvals
Feature: AP_DLock_08
	

@regression
@liveapprentice
@dlockscenarios
Scenario: AP_DLock_08 Triaging and resolving mismatch Datalocks after ILR match - multiple price episodes
Given the Employer has approved apprentice
And the datalock has been successful
When the provider submit an ILR with price mismatch
And the provider submit another ILR with price mismatch
Then provider will see all price episodes on single page