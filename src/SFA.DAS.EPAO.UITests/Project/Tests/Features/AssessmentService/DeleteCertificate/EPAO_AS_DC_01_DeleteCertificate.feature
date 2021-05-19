Feature: EPAO_AS_DC_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_DC_01A - Delete a Certficate 
	Given the Delete Assessor User is logged into Assessment Service Application
	When the User requests wrong certificate certifying an Apprentice as 'pass' which needs 'deleting' 
	Then the User can navigates to record another grade
	And  the Admin user can delete a certificate that has been incorrectly submitted

@epao
@assessmentservice
@regression	
Scenario: EPAO_AS_DC_01B - Recreate the Deleted Certficate 
	Given the Delete Assessor User is logged into Assessment Service Application
	Then  the User is able to rerequest the certificate certifying an Apprentice as 'PassWithExcellence' which was'ReRequesting' 