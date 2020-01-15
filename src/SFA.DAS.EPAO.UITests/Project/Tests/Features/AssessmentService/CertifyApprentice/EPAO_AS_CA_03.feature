Feature: EPAO_AS_CA_03

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_03 - Certify an Apprentice who has enrolled for a more than one standard
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'more than one' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice