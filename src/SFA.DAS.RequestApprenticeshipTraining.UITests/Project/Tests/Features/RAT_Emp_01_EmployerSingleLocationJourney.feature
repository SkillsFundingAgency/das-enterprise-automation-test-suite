Feature: RAT_Emp_01_EmployerSingleLocationJourney

@ratemployer
@regression
@rat
Scenario: RAT_Emp_01_EmployerSingleLocationJourney
	Given an employer requests apprenticeship training
	When the employer logs in to rat employer account
	Then the employer submits the request for single location
