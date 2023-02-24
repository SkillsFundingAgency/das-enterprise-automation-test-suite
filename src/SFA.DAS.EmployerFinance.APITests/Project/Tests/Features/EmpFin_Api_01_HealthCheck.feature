Feature: EmpFin_Api_01_HealthCheck

@api
@employerfinanceapi
@regression
@innerapi
Scenario: ApiHealthCheck
	Then endpoint das-employer-finance-api /ping can be accessed
