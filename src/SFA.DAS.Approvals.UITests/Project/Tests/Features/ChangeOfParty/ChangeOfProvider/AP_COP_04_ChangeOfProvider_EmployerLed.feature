@approvals
Feature: AP_COP_04_ChangeOfProvider_EmployerLed

@regression
@changeOfProvider
@liveapprentice
Scenario: AP_COP_04_Change Of Provider_EmployerLed
	Given the employer has an apprentice with stopped status
	When  employer starts COP process by entering valid details
	Then  allow employer to change their answers before submitting CoP request
	When  new provider approves the cohort
	Then  a new live apprenticeship record is created with new Provider