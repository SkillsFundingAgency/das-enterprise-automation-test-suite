Feature: FatV2Api

@api
@fatv2api
@regression
Scenario Outline: Verify FatV2Api
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received

Examples: 
| TestCaseId | Method | Endpoint               | Payload         | ResponseStatus |
| Fatv2001   | GET    | /epaos/EPA0241         | fatv2epaos.json | OK             |
| Fatv2002   | GET    | /epaos/EPA0241/courses |                 | OK             |
| Fatv2003   | GET    | /epaos                 |                 | OK             |

@api
@fatv2api
@regression
Scenario: Verify FatV2Api EPAO
	When the user sends GET request to /epaos without payload 
	Then a OK response is received