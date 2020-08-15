Feature: EI_NC_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_NC_01_Levy Account with one legal entity and No Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	When the Employer Initiates EI Application journey for Single entity account
	Then Qualification question shutter page is displayed for selecting No option in Qualification page
	And Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page
	When the Employer navigates back to Qualification page
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page