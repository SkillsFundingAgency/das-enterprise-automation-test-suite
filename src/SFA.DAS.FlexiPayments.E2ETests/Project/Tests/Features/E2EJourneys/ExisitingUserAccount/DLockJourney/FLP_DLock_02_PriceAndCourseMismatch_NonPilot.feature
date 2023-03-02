@flexi-payments
Feature: FLP_DLock_02_PriceAndCourseMismatch_NonPilot
	
@regression
@liveapprentice
@dlockscenarios
Scenario: FLP_DLock_02_PriceAndCourseMismatch_NonPilot - Display Pilot DLock Message
	Given the Employer has an approved NonPilot apprentice
	When the provider submit an ILR with price mismatch
	And the provider submit another ILR with course mismatch
	Then validate provider cannot view Pilot DataLock message