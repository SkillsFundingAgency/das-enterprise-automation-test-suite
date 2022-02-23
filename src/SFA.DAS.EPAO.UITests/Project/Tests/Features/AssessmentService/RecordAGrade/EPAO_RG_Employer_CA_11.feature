Feature: EPAO_RG_Employer_CA_11
	
@epao
@assessmentservice
@recordagrade
@regression
@epaoca1standard1version1option
Scenario: EPAO_RG_CA_11A - Certify an Apprentice EmployerRoute as Pass - 1 Standard - 1 Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When  the User certifies an Apprentice as 'pass' using 'employer' route
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'pass'
	
@epao
@assessmentservice
@recordagrade
@regression
@epaoca1standard1version1option
Scenario: EPAO_RG_CA_11B - Certify an Apprentice EmployerRoute as Fail to Pass - 1 Standard - 1 Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'fail' using 'employer' route
	Then the User can navigates to record another grade
	And the Assessment is recorded as 'fail'
	When the User certifies same Apprentice as pass using 'employer' route
	Then the Assessment is recorded as 'pass'