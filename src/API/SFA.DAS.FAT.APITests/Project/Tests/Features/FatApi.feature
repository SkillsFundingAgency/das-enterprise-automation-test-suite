Feature: FatApi

@api
@fatapi
@regression
Scenario Outline: Verify FatApi
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received

Examples: 
| TestCaseId | Method | Endpoint               | Payload       | ResponseStatus |
| Fat001     | GET    | /epaos/EPA0241         | fatepaos.json | OK             |
| Fat002     | GET    | /epaos/EPA0241/courses |               | OK             |
| Fat003     | GET    | /epaos                 |               | OK             |

@api
@fatapi
@regression
Scenario Outline: Verify FatApi course
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus>, <ResponseContent> response is received

Examples: 
| TestCaseId | Method | Endpoint               | Payload | ResponseStatus | ResponseContent |
| Fat004     | GET    | /epaos/EPA0241/courses |         | OK             | EPA0241         |

@api
@fatapi
@regression
Scenario: Verify FatApi EPAO
	When the user sends GET request to /epaos without payload
	Then a OK response is received