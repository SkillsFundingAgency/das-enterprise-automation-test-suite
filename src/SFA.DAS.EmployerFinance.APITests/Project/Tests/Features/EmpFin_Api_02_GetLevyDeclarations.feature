Feature: EmpFin_Api_02_GetLevyDeclarations

@api
@employerfinanceapi
@regression
@innerapi
Scenario: GetLevyDeclarations
	Then endpoint api/accounts/{hashedAccountId}/levy can be accessed
