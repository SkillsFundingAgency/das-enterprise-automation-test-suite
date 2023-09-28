@accessibility
@approvals
Feature: AP_E2E_ACC_Accessibility05
Navigation journey through EAS and PAS 

@ignoreindemo
@ignoreintest
@ignoreintest2
Scenario:  AP_E2E_ACC_05 PublicSectorReporting
	Given the Employer logins using existing NonLevy Account
	Then the employer can create a new report
	And then employer can edit a submitted report
