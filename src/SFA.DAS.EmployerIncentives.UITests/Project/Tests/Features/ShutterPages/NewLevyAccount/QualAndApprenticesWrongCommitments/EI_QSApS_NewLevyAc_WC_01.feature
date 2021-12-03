Feature: EI_QSApS_NewLevyAc_WC_01

@regression
@addlevyfunds
@employerincentivesphase3
Scenario: EI_QSApS_NewLevyAc_WC_01_Validate Shutter pages for New Levy Account with One legal entity having Commitments with start date prior to APR 2022
	Given an Employer creates a Levy Account and Signs the Agreement
	And the employer signs the agreement version 7
	When the Employer adds following apprentices
	| Age         | StartMonth | StartYear |
	| Aged16to24  | 3          | 2022      |
	| AgedAbove25 | 12         | 2022      |
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then Qualification question shutter page is displayed for selecting No option in Qualification page
	And Employer Home page is displayed on clicking on Return to Account Home button on Qualification shutter page
	When the Employer navigates back to Qualification page for Single entity account
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And Approvals home page is displayed on clicking on Add apprentices link on Select apprentices shutter page