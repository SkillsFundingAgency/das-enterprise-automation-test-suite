Feature: EI_URV_01_TransactorUser

@regression
@employerincentives
Scenario: EI_URV_01_Verify EI for Existing Transactor user
	Given the Employer logins using existing transactor user account
	And the employer signs the agreement version 7
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to navigate to EI application Select apprentices page
	And the Employer is able to view EI applications