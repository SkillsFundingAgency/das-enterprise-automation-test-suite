Feature: MetricsData

The API system should allow valid metric data to be posted successfully and also to be retrive


@api
@earlyconapi
@regression
Scenario Outline: Verify api GET Metrics Data 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
| TestCaseId | Method | Endpoint							  | Payload | ResponseStatus |
| EC222      | GET    | /early-connect/metrics-data/E37000025 |         |    OK          | 

@api
@earlyconapi
@regression
Scenario Outline: Verify valid metris data post returns 201 Created 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
| TestCaseId | Method | Endpoint							  | Payload | ResponseStatus |
| EC222      | POST    | /early-connect/metrics-data/add | MetricsData.json  |    Created | 

@api
@earlyconapi
@regression
Scenario Outline: Verify invalid metris data post returns 400 Bad request 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
| TestCaseId | Method | Endpoint							  | Payload | ResponseStatus |
| EC222      | POST    | /early-connect/metrics-data/add | InvalidMetricsData.json  |    Bad Request |
