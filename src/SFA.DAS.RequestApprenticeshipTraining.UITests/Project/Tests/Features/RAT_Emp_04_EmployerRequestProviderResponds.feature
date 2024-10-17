Feature: RAT_Emp_04_EmployerRequestProviderResponds

@ratemployer
@regression
@mailosaur
@rat
Scenario: RAT_Emp_04_EmployerRequestProviderResponds
	Given an employer requests apprenticeship training
	When the employer logs in to rat multi employer account
	Then the employer submits the request for single location
	And a provider responds to the employer request
	And the employer receives the request