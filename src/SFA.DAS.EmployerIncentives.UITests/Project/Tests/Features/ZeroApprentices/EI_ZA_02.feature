Feature: EI_ZA_02

@regression
@addpayedetails
@employerincentives
Scenario: EI_ZA_02_Levy Account with Two legal entities and Zero Apprentices
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds another legal entity
#When the Employer navigates through the EI Application
#When Employer chooses the legal entity
#Then the Shutter page is displayed