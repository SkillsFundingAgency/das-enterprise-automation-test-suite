Feature: EI_EAN_01

@regression
@employerincentives
Scenario: EI_EAN_01_Verify EI for Existing Transactor user
	Given the Employer logins using existing transactor user account
	Then the user can apply for employer incentives
	