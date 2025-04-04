@api
@regression
@raaapi
Feature: EmployerAccountLegalEntities

Scenario Outline: RAA_API_01_OuterApiGetEmployerAccountLegalEntities_
	Given user prepares request with Employer ID
	When the user sends <Method> request to <Endpoint>
	Then a <ResponseStatus> response is received
	And verify response body displays correct information

	Examples:
		| TestCaseId | Method | Endpoint                                                  | ResponseStatus |
		| 001        | GET    | /recruit/employeraccounts/{hashedAccountId}/legalentities | OK             |
		| 002        | GET    | /recruit/employeraccounts/{hashedAccountId}/legalentities | OK             |

Scenario Outline: RAA_API_02_Createvacancy
	When the user sends POST request to vacancy endpoint with <payload>
	Then a <ResponseStatus> response is received
	And verify response body displays vacancy reference number

	Examples: 
	| TestCaseId | ResponseStatus | payload                         |
	| 001        | Created        | singleLocation.json             |
	| 002        | Created        | multipleLocations.json          |
	| 003        | Created        | nationWide.json                 |
	| 004        | Created        | singleLocationAnonymous.json    |
	| 005        | Created        | multipleLocationsAnonymous.json |
	| 006        | Created        | nationwideAnonymous.json        |
