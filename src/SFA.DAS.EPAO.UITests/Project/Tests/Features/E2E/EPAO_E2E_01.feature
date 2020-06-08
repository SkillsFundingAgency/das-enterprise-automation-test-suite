Feature: EPAO_E2E_01

@epao
@epaoapply
@regression
Scenario: EPAO_E2E_01 - Apply Approve and Add a standard
	Given the Apply User is logged into Assessment Service Application
	When the Apply User completes preamble journey
	And the Apply User completes Organisation details section
	And the Apply User completes the Declarations section
	And the Apply User completes the FHA section
	Then the application is allowed to be submitted
