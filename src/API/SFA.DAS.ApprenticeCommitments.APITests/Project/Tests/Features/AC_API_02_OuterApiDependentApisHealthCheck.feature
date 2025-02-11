Feature: OuterApiDependentApiHealthCheck
# https://<env>-apim-acomt-api.apprenticeships.education.gov.uk/health checks the health of the following inner APIs
# ApprenticeCommitmentsHealthCheck
# CommitmentsV2HealthCheck
# TrainingProviderApiHealthCheck
# ApprenticeLoginApiHealthCheck

@api
@apprenticecommitmentsapi
@outerapi
@regression
Scenario: AC_API_02_OuterApiDependentApisHealthCheck
	Then the apprentice commitments api dependent api's are reachable