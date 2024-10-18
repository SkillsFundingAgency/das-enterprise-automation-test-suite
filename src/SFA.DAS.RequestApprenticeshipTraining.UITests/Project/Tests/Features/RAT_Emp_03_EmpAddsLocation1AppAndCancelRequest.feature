Feature: Rat_Emp_03_EmpAddsLocation1AppAndCancelRequest

@ratemployer
@regression
@rat
Scenario: Rat_Emp_03_EmpAddsLocation1AppAndCancelRequest
	Given an employer adds location to requests apprenticeship training
	When the employer logs in to rat cancel employer account
	Then the employer submits the request for one apprentice
	And the employer can cancel the request
