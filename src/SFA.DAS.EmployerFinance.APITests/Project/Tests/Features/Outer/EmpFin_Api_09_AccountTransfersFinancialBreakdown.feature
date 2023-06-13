Feature: EmpFin_Api_09_AccountTransfersFinancialBreakdown

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_09_AccountTransfersFinancialBreakdown
	Then endpoint /Transfers/{accountId}/financial-breakdown can be accessed