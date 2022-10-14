Feature: EmployerAccountsApiHealthCheck

@api
@employeraccountsapi
@regression
@innerapi
Scenario: AC_API_01_HealthCheck
	Then das-employer-accounts-api /ping endpoint can be accessed
