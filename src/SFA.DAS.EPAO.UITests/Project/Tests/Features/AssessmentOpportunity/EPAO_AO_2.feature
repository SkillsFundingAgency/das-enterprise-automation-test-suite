Feature: EPAO_AO_2

@epao
@assessmentservice
@assessmentopportunity
@regression
Scenario: EPAO_AO_2 - View an In-developement Standard in Assessment Opportunity Application
	When the User visits the Assessment Opportunity Application
	And the User clicks on one of the standards listed under 'In-development' tab to view it
	Then the selected In-development standard detail page is displayed 