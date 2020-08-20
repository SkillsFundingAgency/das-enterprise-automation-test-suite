Feature: EI_AS_ELA_01

@regression
@employerincentives
Scenario: EI_AS_ELA_01_Validate Existing Levy account with unsigned V4 Agreement
	Given the Employer logins using existing Levy Account
	When the Employer Initiates EI Application journey for Single entity account
	Then Employer agreement shutter page is displayed for selecting Yes option in the Qualification page
	And Employer Home page is displayed on clicking on Return to Account home link on Employer agreement shutter page
	When the Employer navigates back to Qualification page
	Then Employer agreement shutter page is displayed for selecting Yes option in the Qualification page
	And Your Agreements page is displayed on clicking on View agreement button on Employer agreement shutter page