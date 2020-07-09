@approvals
Feature: AP_DLock_05

@regression
@waitingtostartapprentice
@dlockscenarios
@selectstandardcourse
Scenario: AP_DLock_05 Employer can stop the waiting to start apprentice after Datalocks and ILR match
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with course price mismatch
	Then the Employer can stop the waiting to start apprentice