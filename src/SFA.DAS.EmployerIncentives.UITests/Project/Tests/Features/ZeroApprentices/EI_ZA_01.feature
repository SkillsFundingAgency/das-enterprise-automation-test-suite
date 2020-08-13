Feature: EI_ZA_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_ZA_01_Levy Account with one legal entity and Zero Apprentices
	Given an Employer creates a Levy Account and Signs the Agreement
	When the Employer Initiates EI Application journey for Single entity account
	Then No Eligible apprentices shutter page is displayed for selecting Yes option in Qualification page
	When the Employer navigates back on No Eligible apprentices shutter page
	Then No Eligible apprentices shutter page is displayed for selecting No option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link  