Feature: EPAO_AS_CA_05

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_CA_05 - Certify an already assessed Apprentice
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an already assessed Apprentice
	Then 'An assessment has already been recorded against this apprentice' message is displayed