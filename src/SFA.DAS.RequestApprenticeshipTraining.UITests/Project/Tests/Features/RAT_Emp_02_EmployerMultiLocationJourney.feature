Feature: Rat_Emp_02_EmployerMultiLocationJourney

@ratemployer
@regression
@rat
Scenario: Rat_Emp_02_EmployerMultiLocationJourney
	Given an employer requests apprenticeship training
	When the employer logs in to rat employer account
	Then the employer submits the request for multiple location