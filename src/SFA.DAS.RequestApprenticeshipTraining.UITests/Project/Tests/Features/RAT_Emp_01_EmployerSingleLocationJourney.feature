Feature: RAT_Emp_01_EmployerSingleLocationJourney

@RATEmployer
@regression
@mailosaur
Scenario: RAT_Emp_01_EmployerSingleLocatoinJourney
	Given the User searches a course then navigates to the provider list
	And   the user transitions from FAT to RAT after clicking on ask if training providers can run this course as employer owner
