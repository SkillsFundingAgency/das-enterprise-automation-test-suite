Feature: CreateCertificateForApprenticeships

@api
@AssessorCertification
@EPA API Certification
@regression

Scenario Outline: Verify Certificate can be created for Apprenticeships
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	
	
Examples: 
| TestCaseId          | Method | Endpoint                                         | Payload | ResponseStatus |
| CheckCertificate001 | GET    | /api/v1/certificate/1000809178/Name1000809178/91 |         | NoContent      |


Scenario Outline: Verify Check Certificate for Apprenticeships
	Given the user prepares request with for uln 1000809103
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the CertificateReference in the response is same as in the Certificates table in the database
	
Examples: 
| TestCaseId          | Method | Endpoint                                         | Payload | ResponseStatus |
| CheckCertificate002 | GET    | /api/v1/certificate/1000809103/Name1000809103/91 |         | OK             |

Scenario Outline: Verify Create Certificate
	Given the user prepares payload with uln 1000809100
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the CertificateReference in the response is same as in the Certificates table in the database

Examples: 
| TestCaseId           | Method | Endpoint            | Payload                | ResponseStatus |
| CreateCertificate001 | POST   | /api/v1/certificate | CreateCertificate.json | OK             |

Scenario Outline: Verify Update Certificate
	Given the user prepares request with for uln 1000809103
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the CertificateReference in the response is same as in the Certificates table in the database
	And Action in the Certificatelog is Amend

Examples: 
| TestCaseId           | Method | Endpoint            | Payload                | ResponseStatus |
| UpdateCertificate001 | PUT    | /api/v1/certificate | UpdateCertificate.json | OK             |

Scenario Outline: Verify Delete Certificate
	Given the user prepares request with for uln 1000809104
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And Action in the Certificatelog is Delete
	And the status in the Certificates Table in database is Deleted

Examples: 
| TestCaseId           | Method | Endpoint                                                  | Payload | ResponseStatus |
| DeleteCertificate001 | DELETE | /api/v1/certificate/1000809104/Name1000809104/91/00012026 |         | NoContent      |

Scenario Outline: Verify Get grades
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	
Examples: 
| TestCaseId   | Method | Endpoint                   | Payload | ResponseStatus |
| GetGrades001 | GET    | /api/v1/certificate/grades |         | OK             |