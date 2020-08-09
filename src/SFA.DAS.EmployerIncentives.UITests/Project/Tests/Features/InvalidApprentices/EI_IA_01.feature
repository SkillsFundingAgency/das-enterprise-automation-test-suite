Feature: EI_IA_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_IA_01_Levy Account with one legal entity having Apprentices with start date prior to AUG 2020
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices with start date as JUL 2020
#When the Employer navigates through the EI Application
#Then the Shutter page is displayed