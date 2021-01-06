Feature: GetAEpaoCourses

@fatv2api
@regression
Scenario: FATV2_Api_GetAEpaoCourses
	Given the fatv2 api client is created
	When the user sends GET request to /epaoregister/epaos/EPA0241/courses
	Then a valid response is received
