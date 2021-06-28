Feature: EI_URV_02_ViewOnlyUser

@regression
@employerincentives
Scenario: EI_URV_02_Verify EI for Existing View user
	When the Employer logins using existing view user account
	Then Access to EI Hub is denied to the Employer