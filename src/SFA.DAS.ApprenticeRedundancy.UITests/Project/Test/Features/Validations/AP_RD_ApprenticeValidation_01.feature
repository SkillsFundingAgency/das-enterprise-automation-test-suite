Feature: AP_RD_AP_VL_01

@aprdsupport
@aprd
@aprdvl
@regression
@aprdvl01
Scenario: AP_RD_Apprentice_01_VerifyValidationsApprenticeForm
Given The Apprentice do not complete all the mandatory fields
Then Errors displayed for not completing the mandatory information on Apprentice Form