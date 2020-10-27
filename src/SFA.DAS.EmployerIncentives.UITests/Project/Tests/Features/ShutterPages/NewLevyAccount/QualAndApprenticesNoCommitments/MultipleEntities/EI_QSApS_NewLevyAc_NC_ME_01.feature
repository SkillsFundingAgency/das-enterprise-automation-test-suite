Feature: EI_QSApS_NewLevyAc_NC_ME_01

@regression
@employerincentives
@addpayedetails
@addlevyfunds
Scenario: EI_QSApS_NewLevyAc_NC_ME_01_Validate Shutter pages for New Levy Account with Two legal entities and No Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds another legal entity
	When the Employer Initiates EI Application journey for Multiple entity account
	Then Qualification question shutter page is displayed for selecting No option in Qualification page
	And Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page
	When the Employer navigates back to Qualification page for Multiple entity account
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page