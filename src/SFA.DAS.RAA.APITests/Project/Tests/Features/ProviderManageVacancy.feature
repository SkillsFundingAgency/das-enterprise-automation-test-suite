
Feature: ProviderManageVacancy

@api
@regression
@raaapi
@raaapiprovider
Scenario Outline: RAA_API_03_Pro_Createvacancy_Created
	When the user sends POST request to vacancy with payload <Payload>
	Then a <ResponseStatus> response is received
	And verify response body displays vacancy reference number

	Examples: 
	| TestCaseId | ResponseStatus | Payload                         |
	| 001        | Created        | singleLocation.json             |
	| 002        | Created        | multipleLocations.json          |
	| 003        | Created        | nationWide.json                 |
	| 004        | Created        | singleLocationAnonymous.json    |
	| 005        | Created        | multipleLocationsAnonymous.json |
	| 006        | Created        | nationwideAnonymous.json        |

@api
@regression
@raaapi
@raaapiprovider
@invalidapikey
Scenario Outline: RAA_API_03B_Pro_Createvacancy_Unauthorized
	When the user sends POST request to vacancy with payload <Payload>
	Then a <ResponseStatus> response is received
	And verify response body displays Access denied due to invalid subscription key

	Examples: 
	| TestCaseId | ResponseStatus | Payload             |
	| 001        | Unauthorized   | singleLocation.json |
