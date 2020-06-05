Feature: EPAO_AS_DC_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_DC_01A - Delete a Certficate 
	Given the Delete Assessor User is logged into Assessment Service Application
	When the User requests wrong certificate certifying an Apprentice as 'Passed' which needs 'deleting' 
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice
	And  the Admin user can delete a certificate that has been incorrectly submitted


@epao
@assessmentservice
@regression	
Scenario: EPAO_AS_DC_01B - Recreate the Deleted Certficate 
	Given the Delete Assessor User is logged into Assessment Service Application
	Then  the User is able to rerequest the certificate certifying an Apprentice as 'Passed' which was'ReRequesting' 