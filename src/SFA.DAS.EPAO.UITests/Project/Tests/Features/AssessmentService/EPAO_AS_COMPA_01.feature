Feature: EPAO_AS_COMPA_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_COMPA_01 - View Completed assessments history
	Given the Assessor User is logged into Assessment Service Application
	When the User navigates to the Completed assessments tab
	Then the User is able to view the history of the assessments