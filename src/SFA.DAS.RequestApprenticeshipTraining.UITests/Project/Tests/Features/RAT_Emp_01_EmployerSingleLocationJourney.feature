Feature: RAT_Emp_01_EmployerSingleLocationJourney

@ratemployer
@regression
@mailosaur
@rat
@getcoursesthatproviderdeosnotoffer
Scenario: RAT_Emp_01_EmployerSingleLocatoinJourney
	Given an employer requests apprenticeship trainning
	When the employer logs in to rat employer account
	Then the employer submits the request for single location
