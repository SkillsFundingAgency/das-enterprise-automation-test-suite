Feature: EmpFin_Api_09_AccountTransfersCount

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_09_AccountTransfersCount
	Then endpoint /Transfers/{accountId}/counts can be accessed