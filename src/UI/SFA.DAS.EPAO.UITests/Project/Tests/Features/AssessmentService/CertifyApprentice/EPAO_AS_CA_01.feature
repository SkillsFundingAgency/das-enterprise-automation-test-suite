Feature: EPAO_AS_CA_01

@epao
@assessmentservice
@recordagrade
@regression
@epaoca1standard1version1option
Scenario: EPAO_AS_CA_01A - Verify Change links on the Confirm Assessment Page
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass' with 'apprentice' route and lands on Confirm Assessment Page
	Then the Change links navigate to the respective pages

@epao
@assessmentservice
@recordagrade
@regression
@epaoca1standard1version1option
Scenario: EPAO_AS_CA_01B - Verify Employer Change links on the Confirm Assessment Page
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass' with 'employer' route and lands on Confirm Assessment Page
	Then the Change links navigate to employer pages