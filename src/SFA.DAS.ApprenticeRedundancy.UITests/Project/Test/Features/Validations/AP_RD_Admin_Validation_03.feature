Feature: AP_RD_AD_VL_03

@aprdadmin
@aprd
@aprdvl
@regression
@aprdvl03
Scenario: AP_RD_Admin_03_VerifyValidationsAdminDownload
Given the Admin Successfully Logs into appliation
When the Admin do not complete all the mandatory fields
Then Errors displayed for not completing the mandatory information on Admin Download