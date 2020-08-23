Feature: EI_QSApS_NewLevyAc_WC_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_QSApS_NewLevyAc_WC_01_Validate Shutter pages for New Levy Account with One legal entity having Commitments with start date prior to AUG 2020
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 7 and Year 2020
	When the Employer Initiates EI Application journey for Single entity account
	Then Qualification question shutter page is displayed for selecting No option in Qualification page
	And Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page
	When the Employer navigates back to Qualification page for Single entity account
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page