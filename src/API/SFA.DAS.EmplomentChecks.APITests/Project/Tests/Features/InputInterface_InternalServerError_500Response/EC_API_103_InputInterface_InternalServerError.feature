Feature: InputInterface_InternalServerError_500Response

CheckType value exceeds 50 characters - it is 51 characters

@api
@regression
@employmentcheckapi
Scenario: EC_API_103_InputInterface_InternalServerError
	Given Employer Incentives service are validing employment status of apprentice
	When an employment check '<Method>' request is successfully made to '<Endpoint>' with payload '<Payload>'
	Then a '<ResponseStatus>' response is received
	And the check is '<Registered>' in Employment Check business table
Examples:
	| Method | Endpoint                           | Payload         | ResponseStatus      | Registered |
	| POST   | /api/EmploymentCheck/RegisterCheck | EC_API_103.json | InternalServerError | false      |