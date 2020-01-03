Feature: EPAO_AS_CA_04

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_04 - Certify a privately funded Apprentice
	Given the User is logged into Assessment Service Application
	When the User goes through certifying a Privately funded Apprentice
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice