Feature: EmpFin_Api_08_AccountTransfersCount

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_08_AccountTransfersCount
	Then endpoint /Transfers/{accountId}/counts can be accessed