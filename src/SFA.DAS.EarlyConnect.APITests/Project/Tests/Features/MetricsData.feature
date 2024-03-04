Feature: MetricsData

The API system should allow valid metric data to be posted successfully and also to be retrive


@api
@earlyconapi
@regression
Scenario Outline: Verify api GET Metrics Data 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received
	And verify response body displays correct '<Region>' information

	Examples: 
  | Method | Endpoint                              | Payload | ResponseStatus | Region   |
  | GET    | /early-connect/metrics-data/E37000019 |         | OK             | Lancashire |
  | GET    | /early-connect/metrics-data/E37000025 |         | OK             | North East  |
  | GET    | /early-connect/metrics-data/E37000051 |         | OK             | London      |

@api
@earlyconapi
@regression
Scenario Outline: Verify valid metris data post returns 201 Created 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
 | Method | Endpoint					    | Payload           | ResponseStatus |
 | POST   | /early-connect/metrics-data/add | MetricsData.json  |    Created     | 

@api
@earlyconapi
@regression
Scenario Outline: Verify invalid metris data post returns 400 Bad request 
	When the user sends <Method> request to <Endpoint> with payload <Payload>
	Then api <ResponseStatus> response is received

	Examples: 
 | Method | Endpoint							  | Payload                  | ResponseStatus |
 | POST   | /early-connect/metrics-data/add       | InvalidMetricsData.json  |    Bad Request |
