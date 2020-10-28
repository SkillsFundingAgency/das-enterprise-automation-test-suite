Feature: EI_URV_02

@regression
@employerincentives
Scenario: EI_URV_02_Verify EI for Existing View user
	When the Employer logins using existing view user account
	Then Access to EI Application is denied to the Employer
	And  to the view EI applications