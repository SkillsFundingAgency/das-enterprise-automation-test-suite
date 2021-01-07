Feature: FatV2Api

@fatv2api
@regression
Scenario Outline: Verify FatV2Api
	Given the fatv2 api client is created
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatusCode> response is received

Examples: 
| Endpoint                            | Payload         | ResponseStatusCode | Method |
| /epaoregister/epaos/EPA0241         | fatv2epaos.json | OK                 | GET    |
| /epaoregister/epaos/EPA0241/courses |                 | OK                 | GET    |
| /epaoregister/epaos                 |                 | OK                 | GET    |
