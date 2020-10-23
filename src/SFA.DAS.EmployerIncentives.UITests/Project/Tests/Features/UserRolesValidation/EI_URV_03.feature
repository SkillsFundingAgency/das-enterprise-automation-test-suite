Feature: EI_URV_03

@regression
@employerincentives
Scenario: EI_URV_03_Verify EI for Multiple Accounts user
	Given the Employer logins using existing multiple account user 
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer can continue for eligible apprentices scenario
	When the Employer switches to an account without aprentices
	And the Employer Initiates EI Application journey for Single entity account
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	