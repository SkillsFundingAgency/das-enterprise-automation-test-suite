Feature: CoursesApi


@standardversioningapi
@regression
@api
@innerapi
Scenario: Inner das-courses-api heathcheck
	Then das-courses-api /ping endpoint can be accessed