Feature: Rat_Emp_02_EmployerRequestProviderResponds

@ratemployer
@regression
@rat
Scenario: Rat_Emp_02_EmployerRequestProviderResponds
	Given an employer requests apprenticeship training
	When the employer logs in to rat employer account
	Then the employer submits the request for multiple location
	And a provider responds to the employer request
	And the employer receives the response