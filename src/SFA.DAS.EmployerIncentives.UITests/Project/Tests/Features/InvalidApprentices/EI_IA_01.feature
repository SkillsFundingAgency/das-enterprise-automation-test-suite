Feature: EI_IA_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_IA_01_Levy Account with one legal entity having Apprentices with start date prior to AUG 2020
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 7 and Year 2020
	When the Employer Initiates EI Application journey for Single entity account
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page