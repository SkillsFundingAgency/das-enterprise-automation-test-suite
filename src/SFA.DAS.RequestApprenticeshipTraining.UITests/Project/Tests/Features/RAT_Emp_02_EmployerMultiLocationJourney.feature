Feature: RAT_Emp_02_EmployerMultiLocationJourney

@ratemployer
@regression
@mailosaur
@rat
Scenario: RAT_Emp_02_EmployerMultiLocationJourney
	Given the User searches a course then navigates to the provider list
	And the user clicks on ask if training providers can run this course as employer owner
	Then the Employer logs in using employer RAT Account
	And the employer submits the request for multiple location
