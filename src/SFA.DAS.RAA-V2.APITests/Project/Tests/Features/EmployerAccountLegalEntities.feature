Feature: EmployerAccountLegalEntities

@api
@regression
@raav2api
Scenario Outline: Get Legal Entities
	Given user prepares request with Employer <HashedId>
	When the user sends <Method> request to <Endpoint>
	Then a <ResponseStatus> response is received
	And verify response body displays correct information

	Examples:
		| TestCaseId | HashedId | Method | Endpoint                                 | ResponseStatus |
		| Raav2001   | MKPYBB   | GET    | /vacancies/employeraccountlegalentities/ | OK             |
		| Raav2002   | MBP6YD   | GET    | /vacancies/employeraccountlegalentities/ | OK             |