Feature: RecordAssessmentOutcomes

@api
@AssessorCertification
@EPA API Certification
@regression
Scenario Outline: Verify Create EPA Record
	Given the user prepares payload with uln 1000809110
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the EPARefNumber in the response is same as in the Certificates table in the database

Examples: 
| TestCaseId         | Method | Endpoint    | Payload              | ResponseStatus |
| CreateEPARecord001 | POST   | /api/v1/epa | CreateEPARecord.json | OK             |

Scenario Outline: Verify Update EPA Record
	Given the user prepares update request with uln 1000809111
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the EPARefNumber in the response is same as in the Certificates table in the database

Examples: 
| TestCaseId         | Method | Endpoint    | Payload              | ResponseStatus |
| UpdateEPARecord001 | PUT    | /api/v1/epa | UpdateEPARecord.json | OK             |

Scenario Outline: Verify Delete EPA Record
	Given the user prepares delete request with uln 1000809112
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the status in the Certificates Table in database is Deleted

Examples: 
| TestCaseId         | Method | Endpoint                                          | Payload | ResponseStatus |
| DeleteEPARecord001 | DELETE | /api/v1/epa/1000809112/Name1000809112/91/00012125 |         | NoContent      |