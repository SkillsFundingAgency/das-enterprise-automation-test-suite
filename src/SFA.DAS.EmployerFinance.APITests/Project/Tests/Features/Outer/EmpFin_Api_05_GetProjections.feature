Feature: EmpFin_Api_05_GetProjections

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_05_GetProjections
	Then endpoint /Projections/{accountId} can be accessed