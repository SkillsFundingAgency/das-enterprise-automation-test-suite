Feature: EmployerAccountLegalEntities

@api
@regression
@raav2api
Scenario Outline: RV2_API_
	Given user prepares request with Employer HashedID
	When the user sends <Method> request to <Endpoint>
	Then a <ResponseStatus> response is received
	And verify response body displays correct information

	Examples:
		| TestCaseId | Method | Endpoint                                     | ResponseStatus |
		| 001        | GET    | managevacancies/employeraccountlegalentities | OK             |
		| 002        | GET    | managevacancies/employeraccountlegalentities | OK             |