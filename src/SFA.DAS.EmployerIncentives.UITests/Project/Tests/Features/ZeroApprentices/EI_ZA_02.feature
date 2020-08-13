Feature: EI_ZA_02

@regression
@addpayedetails
@employerincentives
Scenario: EI_ZA_02_Levy Account with Two legal entities and Zero Apprentices
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds another legal entity
	When the Employer Initiates EI Application journey for Multiple entity account
	Then No Eligible apprentices shutter page is displayed for selecting Yes option in Qualification page
	When the Employer navigates back on No Eligible apprentices shutter page
	Then No Eligible apprentices shutter page is displayed for selecting No option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link  