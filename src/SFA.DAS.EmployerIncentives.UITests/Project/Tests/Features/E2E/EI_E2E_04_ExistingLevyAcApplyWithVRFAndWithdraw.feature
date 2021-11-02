Feature: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw

@regression
@employerincentives
@eie2ejourney
@vrfservice
Scenario: EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw
	Given the Employer logins using existing EI Withdraw Levy Account
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application
	And the Employer is able to view EI applications