Feature: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw

@regression
@employerincentives
@eie2ejourney
@deletedincentiveapplication
@vrfservice
Scenario: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw
	Given the Employer logins using existing EI Withdraw Levy Account
	And the Employer submits an EI Application
	Then the Employer can withdraw the application
	