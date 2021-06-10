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
	Given the user prepares request with uln 1000809103
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
| TestCaseId        | Method | Endpoint            | Payload                | ResponseStatus |
| CreateCertificate | POST   | /api/v1/certificate | CreateCertificate.json | OK             |

Scenario Outline: Verify Update Certificate
	Given the user prepares request with uln 1000809103
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the CertificateReference in the response is same as in the Certificates table in the database
	And Action in the Certificatelog is Amend

Examples: 
| TestCaseId        | Method | Endpoint            | Payload                | ResponseStatus |
| UpdateCertificate | PUT    | /api/v1/certificate | UpdateCertificate.json | OK             |

Scenario Outline: Verify Submit Certificate
	Given the user prepares request for submission with uln 1000813998 
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And Action in the Certificatelog is Submit
	And the status in the Certificates Table in database is Submitted
	And the currentStatus in the response message is Submitted

Examples: 
| TestCaseId        | Method | Endpoint                   | Payload                | ResponseStatus |
| SubmitCertificate | POST   | /api/v1/certificate/submit | SubmitCertificate.json | OK             |

Scenario Outline: Verify Delete Certificate
	Given the user prepares request with uln 1000809104
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And Action in the Certificatelog is Delete
	And the status in the Certificates Table in database is Deleted

Examples: 
| TestCaseId        | Method | Endpoint                                                  | Payload | ResponseStatus |
| DeleteCertificate | DELETE | /api/v1/certificate/1000809104/Name1000809104/91/00012026 |         | NoContent      |

Scenario Outline: Verify Get grades
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	
Examples: 
| TestCaseId | Method | Endpoint                   | Payload | ResponseStatus |
| GetGrades  | GET    | /api/v1/certificate/grades |         | OK             |

Scenario Outline: Verify Get Options
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	
Examples: 
| TestCaseId                 | Method | Endpoint                          | Payload | ResponseStatus |
| GetOptions                 | GET    | /api/v1/standards/options         |         | OK             |
| GetOptionsStandards        | GET    | /api/v1/standards/options/619     |         | OK             |
| GetOptionsStandardsVersion | GET    | /api/v1/standards/options/619/1.0 |         | OK             |

