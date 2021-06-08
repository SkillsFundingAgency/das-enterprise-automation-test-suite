Feature: LearnerDetails

@api
@AssessorCertification
@EPA API Certification
@regression

Scenario Outline: Verify Learner Details held by the Assessor Service
	Given the user prepares request with for uln 1000809104
	When the user sends <Method> request to <Endpoint> with payload <Payload> 
	Then a <ResponseStatus> response is received
	And the Learner ULn in the response is same as Uln in the Ilrs table in the database
	
Examples: 
| TestCaseId        | Method | Endpoint                                     | Payload | ResponseStatus |
| LearnerDetails001 | GET    | /api/v1/learner/1000809104/Name1000809104/91 |         | OK             |  