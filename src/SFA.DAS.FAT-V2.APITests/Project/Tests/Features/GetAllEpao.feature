Feature: GetAllEpao

@fatv2api
@regression
Scenario: FATV2_Api_GetAllEpao
	Given the fatv2 api client is created
	When the user sends request to /epaoregister/epaos
	Then a valid response is received
