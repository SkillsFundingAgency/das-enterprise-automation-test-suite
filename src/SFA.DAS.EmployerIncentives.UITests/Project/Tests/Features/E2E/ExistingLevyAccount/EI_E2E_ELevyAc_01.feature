Feature: EI_E2E_ELevyAc_01

@regression
@employerincentives
@dfeuatachieveservice
@eie2ejourney
Scenario: EI_E2E_ELevyAc_01_Existing Levy Account with one legal entity adds commitments and applies for Incentive
	When the Employer logins using existing EI Levy Account
	Then View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications
	And EI Start page is displayed on clicking on Apply for the payment link on View EI applications shutter page
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And the Employer is able to view EI applications