Feature: EmpFin_Api_04_GetPledges

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_04_GetPledges
	Then endpoint /Pledges?accountId={accountId} can be accessed