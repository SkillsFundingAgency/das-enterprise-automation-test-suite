Feature: EPAO_RG_CA_06

@epao
@recordagrade
@regression
@epaoca2standard1version1option
Scenario: EPAO_RG_CA_06A - Certify an Apprentice as Pass - multiple Standard - 1 Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'pass'

@epao
@recordagrade
@regression
@epaoca2standard1version1option
Scenario: EPAO_RG_CA_06B - Certify an Apprentice as Fail to Pass - multiple Standard - 1 Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail'
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'fail'
	When the User certifies same Apprentice as pass
	Then the Assessment is recorded as 'pass'