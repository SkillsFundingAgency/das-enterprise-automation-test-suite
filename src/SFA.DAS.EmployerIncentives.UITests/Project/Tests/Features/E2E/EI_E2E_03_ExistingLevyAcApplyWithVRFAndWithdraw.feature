Feature: EI_E2E_03_ExistingLevyAcApplyWithVRFAndWithdraw

@regression
@employerincentivesphase3
@eie2ejourney
@deleteincentiveapplication
@vrfservice
Scenario: EI_E2E_03_ExistingLevyAcApplyWithVRFAndWithdraw
	Given the Employer logins using existing EI Levy Account to withdraw application
	And the employer signs the agreement version 7
	And the Employer submits an EI Application
	Then the Employer can withdraw the application
	