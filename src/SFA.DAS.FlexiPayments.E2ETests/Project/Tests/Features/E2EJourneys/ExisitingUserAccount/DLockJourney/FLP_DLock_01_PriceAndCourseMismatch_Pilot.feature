Feature: FLP_DLock_01_PriceAndCourseMismatch_Pilot
	
@regression
@liveapprentice
@dlockscenarios
@flexi-payments
Scenario: FLP_DLock_01_PriceAndCourseMismatch_Pilot - Display Pilot DLock Message
	Given the Employer has an approved Pilot apprentice
	When the provider submit an ILR with price mismatch
	And the provider submit another ILR with course mismatch
	Then validate provider can view Pilot DataLock message