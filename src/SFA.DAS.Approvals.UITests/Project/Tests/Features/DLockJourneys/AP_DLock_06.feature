@approvals
Feature: AP_DLock_06
	
@regression
@liveapprentice
@dlockscenarios
Scenario: AP_DLock_06 Triaging and resolving mismatch Datalocks before ILR match - display course and price mismatch on single page
	Given the Employer has approved apprentice
	When the provider submit an ILR with price mismatch
	And the provider submit another ILR with course mismatch
	Then both mismatches are displayed on single page
	When provider requests Employer to update details in MA
	Then the Employer can approve the ILR mismatch changes
	And the ILR should be matched and datalock is resolved