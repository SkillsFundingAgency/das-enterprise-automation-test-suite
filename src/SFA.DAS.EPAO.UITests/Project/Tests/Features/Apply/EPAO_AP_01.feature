Feature: EPAO_AP_01

@epao
@assessmentservice
@epaoapply
@regression
Scenario: EPAO_AP_01 - Apply to become Assessor Happy path
	Given the Apply User is logged into Assessment Service Application
	When the Apply User completes preamble journey of Organisation Section
	And organisation details section 
