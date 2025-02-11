Feature: InputInterface_CheckIsRegisteredWithEmploymentCheck

@api
@regression
@employmentcheckapi
Scenario: EC_API_101_InputInterface_CheckIsRegistered
	Given Employer Incentives service are validing employment status of apprentice
	When an employment check '<Method>' request is successfully made to '<Endpoint>' with payload '<Payload>'
	Then a '<ResponseStatus>' response is received
	And the check is '<Registered>' in Employment Check business table
Examples:
	| Method | Endpoint                           | Payload         | ResponseStatus | Registered |
	| POST   | /api/EmploymentCheck/RegisterCheck | EC_API_101.json | OK             | true       |
	