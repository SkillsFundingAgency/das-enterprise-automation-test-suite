Feature: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw

@regression
@employerincentivesphase3
@eie2ejourney
@deleteincentiveapplication
@vrfservice
Scenario: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw
	Given the Employer logins using existing EI Levy Account to withdraw application
	And the Employer submits an EI Application
	Then the Employer can withdraw the application
	