
Feature: InputInterface_BadRequest_400Response

CorreclationId is not provided in the request 

@api
@regression
@employmentcheckapi
Scenario: EC_API_102_InputInterface_BadRequest
	Given Employer Incentives service are validing employment status of apprentice
	When an employment check '<Method>' request is successfully made to '<Endpoint>' with payload '<Payload>'
	Then a '<ResponseStatus>' response is received
	And the check is '<Registered>' in Employment Check business table
Examples:
	| Method | Endpoint                           | Payload         | ResponseStatus | Registered |
	| POST   | /api/EmploymentCheck/RegisterCheck | EC_API_102.json | BadRequest     | false      |