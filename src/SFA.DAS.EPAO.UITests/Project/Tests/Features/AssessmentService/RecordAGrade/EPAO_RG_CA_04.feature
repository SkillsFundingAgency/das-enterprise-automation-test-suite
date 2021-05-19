Feature: EPAO_RG_CA_04

@epao
@recordagrade
@regression
@epaoca1standard2version1option
Scenario: EPAO_RG_CA_04A - Certify an Apprentice as Pass - 1 Standard - Multiple Version - With Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the User can navigates to record another grade

		
@epao
@recordagrade
@regression
@epaoca1standard2version1option
Scenario: EPAO_RG_CA_04B - Certify an Apprentice as Fail - 1 Standard - Multiple Version - With Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail'
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'fail'


@epao
@recordagrade
@regression
@epaoca1standard2version1option
Scenario: EPAO_RG_CA_04C - Certify an Apprentice as Fail to Pass - 1 Standard - Multiple Version - With Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail'
	Then the User can navigates to record another grade
	When the User certifies same Apprentice as pass
	Then the Assessment is recorded as 'pass'