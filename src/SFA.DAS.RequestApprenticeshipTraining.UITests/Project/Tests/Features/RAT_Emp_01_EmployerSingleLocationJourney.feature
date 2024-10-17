Feature: RAT_Emp_01_EmployerJourney

@ratemployer
@regression
@rat
Scenario: RAT_Emp_01A_EmployerSingleLocationJourney
	Given an employer requests apprenticeship training
	When the employer logs in to rat employer account
	Then the employer submits the request for single location


@ratemployer
@regression
@rat
Scenario: RAT_Emp_01B_EmployerMultiLocationJourney
	Given an employer requests apprenticeship training
	When the employer logs in to rat employer account
	Then the employer submits the request for multiple location