Feature: AssessorCertification

@api
@AssessorCertification
@regression
Scenario Outline: Verify Create EPA Record
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received

Examples: 
| TestCaseId         | Method | Endpoint                                       | Payload              | ResponseStatus |
| CreateEPARecord001 | POST   | /api/v1/epa                                    | CreateEPARecord.json | OK             |
##| CreateEPARecord002 | PUT    | /api/v1/epa                                    | CreateEPARecord.json | OK             |
##| CreateEPARecord003 | GET    | /ap1/v1/learner/1000813800/Name1000813800/1381 |                      | NotFound       |