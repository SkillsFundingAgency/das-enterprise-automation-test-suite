@approvals
Feature: DLockJourneyFive

@regression
@waitingtostartapprentice
@dlockscenarios
Scenario: DLOCK5 Employer can not stop the waiting to start apprentice after Datalocks and ILR match
	Given the Employer has approved apprentice
	And the datalock has been successful
	When the provider submit an ILR with course price mismatch
	Then the Employer can not stop the waiting to start apprentice