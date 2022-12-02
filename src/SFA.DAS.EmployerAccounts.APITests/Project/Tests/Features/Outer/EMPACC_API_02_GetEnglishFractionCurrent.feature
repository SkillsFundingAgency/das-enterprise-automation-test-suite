Feature: EMPACC_API_02_GetEnglishFractionCurrent

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EMPACC_API_02_GetEnglishFractionCurrent
	Then endpoint /Accounts/{hashedAccountId}/levy/english-fraction-current can be accessed