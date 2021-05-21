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
| CreateEPARecord001POST | POST   | /api/v1/epa | CreateEPARecord.json | OK             |
#
#Scenario Outline: Verify UPDATES EPA Record
#	##Given the user prepares payload with uln 1000813800
#	When the user sends <Method> request to <Endpoint> with payload <Payload> 
#	Then a <ResponseStatus> response is received
#	And the EPARefNumber in the response is same as in the Certificates table in the database
#
#Examples: 
#| TestCaseId             | Method | Endpoint    | Payload              | ResponseStatus |
#| CreateEPARecord001POST | POST   | /api/v1/epa | CreateEPARecord.json | OK             |