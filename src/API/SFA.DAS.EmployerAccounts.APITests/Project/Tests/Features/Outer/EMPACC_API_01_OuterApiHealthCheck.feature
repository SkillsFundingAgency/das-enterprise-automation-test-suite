Feature: EMPACC_API_01_OuterApiHealthCheck
# https://<env>-apim-empacc-api.apprenticeships.education.gov.uk/ping checks the health of the Outer API only

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EMPACC_API_01_OuterApiHealthCheck
	Then the employer accounts outer api is reachable