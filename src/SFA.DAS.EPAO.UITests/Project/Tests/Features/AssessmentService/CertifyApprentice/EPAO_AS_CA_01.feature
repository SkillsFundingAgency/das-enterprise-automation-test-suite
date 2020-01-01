Feature: EPAO_AS_CA_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_01A - Certify an Apprentice as Passed who has enrolled for a single standard
	Given the User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'single' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_01B - Certify an Apprentice as Failed who has enrolled for a single standard
	Given the User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Failed' who has enrolled for 'single' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice