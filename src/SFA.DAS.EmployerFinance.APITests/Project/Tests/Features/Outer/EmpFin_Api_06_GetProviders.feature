Feature: EmpFin_Api_06_GetProviders

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_06_GetProviders
	Then endpoint /Providers can be accessed
	And endpoint /Profiders/{id} can be accessed