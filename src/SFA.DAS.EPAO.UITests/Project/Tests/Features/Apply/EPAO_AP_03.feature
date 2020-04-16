Feature: EPAO_AP_03

@epao
@epaoapply
#@regression
Scenario: EPAO_AP_03 - Apply Additional Standard
	Given the Standard Apply User is logged into Assessment Service Application
	Then the user can apply to assess a standard
