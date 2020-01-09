Feature: EPAO_AO_3

@epao
@assessmentservice
@assessmentopportunity
@regression
Scenario: EPAO_AO_3 - View an Proposed Standard in Assessment Opportunity Application
	When the User visits the Assessment Opportunity Application
	And the User clicks on one of the standards listed under 'Proposed' tab to view it
	Then the selected Proposed standard detail page is displayed