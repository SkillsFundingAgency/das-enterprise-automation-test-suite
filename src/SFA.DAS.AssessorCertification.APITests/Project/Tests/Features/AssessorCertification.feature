Feature: EPA API Certification

@api
@AssessorCertification
@EPA API Certification
@regression
Scenario Outline: Verify Create EPA Record
	Given the user prepares payload with uln 1000813800
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the EPARefNumber in the response is same as in the Certificates table in the database

Examples: 
| TestCaseId             | Method | Endpoint    | Payload              | ResponseStatus |
| CreateEPARecord001 | POST   | /api/v1/epa | CreateEPARecord.json | OK             |

Scenario Outline: Verify Update EPA Record
	Given the user prepares payload with updated epa outcome for uln 1000809178
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the EPARefNumber in the response is same as in the Certificates table in the database

Examples: 
| TestCaseId         | Method | Endpoint    | Payload              | ResponseStatus |
| UpdateEPARecord001 | PUT    | /api/v1/epa | UpdateEPARecord.json | OK             |