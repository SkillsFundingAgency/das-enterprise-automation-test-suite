Feature: EPAO_AP_03
#This test can be re-purposed for the managed standards journey coming in the future
@ignore
@epao
@epaoapply
@regression
Scenario: EPAO_AP_03 - Apply Additional Standard
	Given the Standard Apply User is logged into Assessment Service Application
	Then the user can apply to assess a standard
