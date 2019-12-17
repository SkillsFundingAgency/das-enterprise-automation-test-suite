Feature: EPAO_AS_CA_01

@assessmentservice
@regression
Scenario: EPAO_AS_CA_01 - Certify an Apprentice who has enrolled for a single standard
	Given the User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice who has enrolled for 'single' standard
	Then the Assessment is recorded successfully
	And the User is able to navigate back to certifying another Apprentice