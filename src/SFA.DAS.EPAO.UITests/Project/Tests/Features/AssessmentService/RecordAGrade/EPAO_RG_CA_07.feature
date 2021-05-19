Feature: EPAO_RG_CA_07

@epao
@recordagrade
@regression
@epaoca2standard2version0option
Scenario: EPAO_RG_CA_07A - Certify an Apprentice as Pass - multiple Standard - multiple Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the User can navigates to record another grade

					
@epao
@recordagrade
@regression
@epaoca2standard2version0option
Scenario: EPAO_RG_CA_07B - Certify an Apprentice as Fail - Multiple Standard - 1 Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail'
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'fail'


@epao
@recordagrade
@regression
@epaoca2standard2version0option
Scenario: EPAO_RG_CA_07C - Certify an Apprentice as Fail to Pass - Multiple Standard - 1 Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail'
	Then the User can navigates to record another grade
	When the User certifies same Apprentice as pass
	Then the Assessment is recorded as 'pass'