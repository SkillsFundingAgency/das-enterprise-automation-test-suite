Feature: EMPACC_API_03_GetEnglishFractionHistory

@api
@employerfinanceapi
@outerapi
@regression
Scenario: EMPACC_API_03_GetEnglishFractionHistory
	Then endpoint /Accounts/{hashedAccountId}/levy/english-fraction-history can be accessed