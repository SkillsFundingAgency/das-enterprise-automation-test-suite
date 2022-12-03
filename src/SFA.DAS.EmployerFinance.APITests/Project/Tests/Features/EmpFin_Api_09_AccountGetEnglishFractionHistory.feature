Feature: EmpFin_Api_09_AccountGetEnglishFractionHistory

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_09_AccountGetEnglishFractionHistory
	Then endpoint api/accounts/{hashedAccountId}/levy/english-fraction-history can be accessed