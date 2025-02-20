Feature: EPAO_Accessibility_05

@accessibility
@epao
@assessmentservice
@regression
Scenario: EPAO_Accessibility_05 - View Completed assessments history
	Given the Assessor User is logged into Assessment Service Application
	When the User navigates to the Completed assessments tab
	Then the User is able to view the history of the assessments