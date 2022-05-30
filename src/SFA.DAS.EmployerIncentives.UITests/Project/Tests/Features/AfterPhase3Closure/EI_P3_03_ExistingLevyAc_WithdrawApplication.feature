Feature: EI_P3_03_ExistingLevyAc_WithdrawApplication

@regression
@employerincentives
@addincentiveapplication
Scenario: EI_P3_03_ExistingLevyAc_WithdrawApplication
	Given the Employer logins using existing EI Levy Account to withdraw application
	Then the Employer can withdraw the application
	