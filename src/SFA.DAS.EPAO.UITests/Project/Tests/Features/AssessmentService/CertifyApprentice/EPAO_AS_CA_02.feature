Feature: EPAO_AS_CA_02

@epao
@assessmentservice
@recordagrade
@regression
@epaoca2standard2version1option
Scenario: EPAO_AS_CA_02B - Verify Change links on the Confirm Assessment Page
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass' and lands on Confirm Assessment Page
	Then the Change links navigate to the respective pages

@epao
@assessmentservice
@recordagrade
@regression
@epaoca2standard2version1option
Scenario: EPAO_AS_CA_02C - Verify Employer Change links on the Confirm Assessment Page
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass' and lands on Confirm Assessment Page
	Then the Change links navigate to employer pages