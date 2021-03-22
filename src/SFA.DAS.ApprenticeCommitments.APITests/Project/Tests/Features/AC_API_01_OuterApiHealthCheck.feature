Feature: OuterApiHealthCheck
# https://<env>-apim-acomt-api.apprenticeships.education.gov.uk/ping checks the health of the Outer API only

@api
@apprenticecommitmentsapi
@outerapi
@regression
Scenario: AC_API_01_OuterApiHealthCheck
	Then the apprentice commitments api is reachable