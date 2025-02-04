Feature: EPAO_AO_01

@epao
@assessmentopportunity
@regression
Scenario: EPAO_AO_01 - View an Approved Standard in Assessment Opportunity Application
	When the User visits the Assessment Opportunity Application
	Then the Approved tab is displayed and selected
	When the User clicks on one of the standards listed under 'Approved' tab to view it
	Then the selected Approved standard detail page is displayed