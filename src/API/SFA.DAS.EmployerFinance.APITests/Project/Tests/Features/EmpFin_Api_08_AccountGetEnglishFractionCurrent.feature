Feature: EmpFin_Api_08_AccountGetEnglishFractionCurrent

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EmpFin_Api_08_AccountGetEnglishFractionCurrent
	Then endpoint api/accounts/{hashedAccountId}/levy/english-fraction-current can be accessed