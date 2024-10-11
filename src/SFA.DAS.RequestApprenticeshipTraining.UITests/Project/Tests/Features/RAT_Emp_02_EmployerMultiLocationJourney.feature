Feature: RAT_Emp_02_EmployerMultiLocationJourney

@ratemployer
@regression
@mailosaur
@rat
Scenario: RAT_Emp_02_EmployerMultiLocationJourney
	Given an employer requests apprenticeship trainning
	When the employer logs in to rat employer account
	Then the employer submits the request for multiple location
