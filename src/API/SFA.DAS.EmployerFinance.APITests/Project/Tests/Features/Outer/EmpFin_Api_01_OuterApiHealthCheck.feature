Feature: EmpFin_Api_01_OuterApiHealthCheck
# https://<env>-apim-empfin-api.apprenticeships.education.gov.uk/ping checks the health of the Outer API only

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_01_OuterApiHealthCheck
	Then the employer finance outer api is reachable