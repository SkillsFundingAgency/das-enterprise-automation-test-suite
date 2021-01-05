Feature: FatV2Api

@fatv2api
@regression
Scenario Outline: Verify FatV2Api
	Given the fatv2 api client is created
	When the user sends request to /epaoregister/epaos/EPA0241
	Then a valid response is received

Examples: 
| Method | Endpoint                            | Body                     |
| GET    | /epaoregister/epaos/EPA0241         |                          |
| GET    | /epaoregister/epaos/EPA0241/courses |                          |
| GET    | /epaoregister/epaos                 |                          |
| POST   | /epaoregister/epaos                 | consolidatedsupport.json |
