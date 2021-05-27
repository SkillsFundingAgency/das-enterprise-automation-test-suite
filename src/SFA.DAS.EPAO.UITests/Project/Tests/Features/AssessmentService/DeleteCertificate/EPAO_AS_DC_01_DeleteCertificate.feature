Feature: EPAO_AS_DC_01

@epao
@assessmentservice
@recordagrade
@regression
@epaoca1standard1version1option
Scenario: EPAO_AS_DC_01A - Delete a Certficate and Recreate the Deleted Certficate 
	Given the Delete Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the User can navigates to record another grade
	Then the Assessment is recorded as 'pass'
	Then the Admin user can delete a certificate that has been incorrectly submitted
	Then the assessor user returns to dashboard
	When the User certifies same Apprentice as PassWithExcellence
	Then the User can navigates to record another grade
	Then the Assessment is recorded as 'pass with excellence'
