Feature: EPAO_AS_CA_03

@epao
@assessmentservice
@recordagrade
@regression
@epaoca2standard1version0option
Scenario: EPAO_AS_CA_03 - Certify an Apprentice who has enrolled for a multiple standard
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'multiple' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice