Feature: GetAEpao

@fatv2api
@regression
Scenario: FATV2_Api_GetAEpao
	Given the fatv2 api client is created
	When the user sends request to /epaoregister/epaos/EPA0241
	Then a valid response is received
