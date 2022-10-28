Feature: OuterApiHealthCheck
# https://<env>-apim-acomt-api.apprenticeships.education.gov.uk/ping checks the health of the Outer API only

@api
@employerfinanceapi
@regression
@innerapi
Scenario: AC_API_01_OuterApiHealthCheck
	Then das-employer-finance-api /ping endpoint can be accessed