Feature: EPAO_AS_CA_02

@epao
@assessmentservice
@recordagrade
@regression
@epaoca2standard1version0option
Scenario: EPAO_AS_CA_02A - Certify an Apprentice who has enrolled for a Standard with Additional Learning option
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'additional learning option' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_02B - Verify Change links on the Confirm Assessment Page
	When the Assessor User is on the Confirm Assessment Page
	Then the Change links navigate to the respective pages