Feature: EPAO_AO_1

@epao
@assessmentservice
@assessmentopportunity
@regression
Scenario: EPAO_AO_1 - Certify an Apprentice as Passed who has enrolled for a single standard
	When the User visits the Assessment Opportunity Application
	Then the Approved tab is displayed
	When the User clicks on one of the standards listed under 'Approved' tab
	Then the respective standard details page is displayed
	When the User clicks on 'Apply to assess this Standard'
	Then the User is redirected to 'Assessment Service' application