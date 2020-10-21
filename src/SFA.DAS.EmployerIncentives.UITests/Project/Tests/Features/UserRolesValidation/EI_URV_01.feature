Feature: EI_URV_01

@regression
@employerincentives
Scenario: EI_URV_01_Verify EI for Existing Transactor user
	Given the Employer logins using existing transactor user account
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer can continue for eligible apprentices scenario
	And the Employer is able to navigate to View Applications page
	