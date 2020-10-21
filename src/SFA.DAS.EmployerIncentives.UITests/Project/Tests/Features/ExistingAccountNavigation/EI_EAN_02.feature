Feature: EI_EAN_02

@regression
@employerincentives
Scenario: EI_EAN_02_Verify EI for Existing View user
	Given the Employer logins using existing view user account
	Then the user can not apply for employer incentives
	