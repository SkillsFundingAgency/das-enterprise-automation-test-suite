@api
@regression
@raaapi
Feature: EmployerAccountLegalEntities

Scenario Outline: RAA_API_01_OuterApiGetEmployerAccountLegalEntities
	Given user prepares request with Employer ID
	When the user sends <Method> request to <Endpoint>
	Then a <ResponseStatus> response is received
	And verify response body displays correct information

	Examples:
		| TestCaseId | Method | Endpoint                                          | ResponseStatus |
		| 001        | GET    | /employeraccounts/{hashedAccountId}/legalentities | OK             |
		| 002        | GET    | /employeraccounts/{hashedAccountId}/legalentities | OK             |
