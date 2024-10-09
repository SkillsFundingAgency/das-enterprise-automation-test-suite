Feature: RAT_Emp_01_EmployerSingleLocationJourney

@ratemployer
@regression
@mailosaur
@rat
Scenario: RAT_Emp_01_EmployerSingleLocatoinJourney
	Given the User searches a course then navigates to the provider list
	And the user clicks on ask if training providers can run this course as employer owner
	Then the Employer logs in using employer RAT Account
