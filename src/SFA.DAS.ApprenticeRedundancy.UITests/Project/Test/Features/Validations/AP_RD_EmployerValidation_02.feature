Feature: AP_RD_EM_VL_02

@aprdsupport
@aprd
@aprdvl
@regression
@aprdvl02
Scenario: AP_RD_Employer_02_VerifyValidationsEmployerForm
Given The Employer do not complete all the mandatory fields
Then Errors displayed for not completing the mandatory information on Employer Form