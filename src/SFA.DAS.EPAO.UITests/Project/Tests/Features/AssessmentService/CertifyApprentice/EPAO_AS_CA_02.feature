Feature: EPAO_AS_CA_02

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_02 - Certify an Apprentice who has enrolled for a Standard with Additional Learning option
	Given the User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'additional learning option' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice