
Feature: ProviderDisplayAdvertApi

@api
@regression
@raaapi
@raaapiprovider
Scenario Outline: RAA_API_05_Pro_OuterApiDisplayAdvertApi_Ok
	When the user sends a GET request to <Endpoint>
	Then a <ResponseStatus> response status is received
	And verify response body displays <Expected> data

	Examples:
		| TestCaseId | Method | Endpoint                      | ResponseStatus | Expected             |
		| 001        | GET    | /accountlegalentities         | OK             | accountLegalEntities |
		| 002        | GET    | /referencedata/courses/routes | OK             | routes               |
		| 003        | GET    | /referencedata/courses        | OK             | trainingCourses      |
		| 004        | GET    | /vacancy                      | OK             | vacancies            |
		| 005        | GET    | /vacancy/vacancyref           | OK             | vacancyReference     |


@api
@regression
@raaapi
@raaapiprovider
@invalidapikey
Scenario Outline: RAA_API_05B_Pro_OuterApiDisplayAdvertApi_Unauthorized
	When the user sends a GET request to <Endpoint>
	Then a <ResponseStatus> response status is received
	And verify response body displays Access denied due to invalid key

	Examples:
		| TestCaseId | Method | Endpoint                      | ResponseStatus |
		| 001        | GET    | /accountlegalentities         | Unauthorized   |
		| 002        | GET    | /referencedata/courses/routes | Unauthorized   |
		| 003        | GET    | /referencedata/courses        | Unauthorized   |
		| 004        | GET    | /vacancy                      | Unauthorized   |
		| 005        | GET    | /vacancy/vacancyref           | Unauthorized   |